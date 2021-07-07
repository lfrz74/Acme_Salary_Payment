using Acme_Salary_Payment.Data;
using Acme_Salary_Payment.DTO;
using Acme_Salary_Payment.Interfaces;
using Acme_Salary_Payment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme_Salary_Payment.Services
{
    public class CalculateSalaryService : ICalculateSalaryService
    {
        public async Task<List<EmployeeDTO>> CalculateEmployeeSalary(List<string> listEmp, List<DayRate> list_rates)
        {
            //Variables
            string dayw = string.Empty;
            DateTime dtFrom;
            DateTime dtTo;
            List<EmployeeDTO> listEmployee = new List<EmployeeDTO>();
            double totalHours = 0d;
            decimal totalAmount = 0m;
            EmployeeDTO emp;
            string[] r;
            List<DayRate> list_day_selected;
            DayRate day_f = null;
            DayRate day_t = null;

            //Processing each line of the file
            listEmp.ForEach(s => {

                r = s.Split(new char[] { '=', ',' });
                emp = new EmployeeDTO()
                {
                    Employee = r[0],
                    Amount = 0
                };

                for (int i = 1; i < r.Length; i++)
                {
                    dayw = r[i].Substring(0, 2);
                    list_day_selected = list_rates.Where(lr => lr.code_day.Equals(dayw.ToUpper()))
                        .OrderBy(lr => lr.order).ToList();
                    dtFrom = new DateTime(1900, 1, 1,
                        Convert.ToInt32(r[i].Substring(2, 2)),
                        Convert.ToInt32(r[i].Substring(5, 2)), 0);
                    dtTo = new DateTime(1900, 1, 1,
                        Convert.ToInt32(r[i].Substring(8, 2)),
                        Convert.ToInt32(r[i].Substring(11, 2)), 0);
                    list_day_selected.ForEach(ds =>
                    {
                        if (IsInTimeRange(dtFrom, ds.hour_from, ds.hour_to))
                        {
                            day_f = ds;
                        }
                        if (IsInTimeRange(dtTo, ds.hour_from, ds.hour_to))
                        {
                            day_t = ds;
                        }
                    });
                    //Payment logic
                    if (day_f.order == day_t.order) //same range of hours
                    {
                        totalHours = Math.Abs((dtTo - dtFrom).TotalHours);
                        totalAmount = (decimal)totalHours * day_f.rate;
                        emp.Amount += totalAmount;
                    }
                    if ((day_t.order - day_f.order) == 1) // consecutive ranges of hours
                    {
                        totalHours = Math.Abs((day_f.hour_to - dtFrom).TotalHours); //From
                        totalAmount = (decimal)totalHours * day_f.rate;
                        emp.Amount += totalAmount;
                        totalHours = Math.Abs((dtTo - day_t.hour_from).TotalHours); //To
                        totalAmount = (decimal)totalHours * day_t.rate;
                        emp.Amount += totalAmount;
                    }
                    if ((day_t.order - day_f.order) > 1) // non consecutive ranges of hours
                    {
                        totalHours = Math.Abs((day_f.hour_to - dtFrom).TotalHours); //From
                        totalAmount = (decimal)totalHours * day_f.rate;
                        emp.Amount += totalAmount;
                        //For intermediate ranges, right now there is just one, but they could be more
                        for (int j = day_f.order; j < (day_t.order - day_f.order); j++)
                        {
                            totalHours = Math.Abs(
                                (list_day_selected[j].hour_to - list_day_selected[j].hour_from).TotalHours);
                            totalAmount = (decimal)totalHours * list_day_selected[j].rate;
                            emp.Amount += totalAmount;
                        }
                        totalHours = Math.Abs((dtTo - day_t.hour_from).TotalHours); //To
                        totalAmount = (decimal)totalHours * day_t.rate;
                        emp.Amount += totalAmount;
                    }
                }

                listEmployee.Add(emp);
            });
            return listEmployee;
        }
        public bool IsInTimeRange(DateTime obj, DateTime timeRangeFrom, DateTime timeRangeTo)
        {
            TimeSpan time = obj.TimeOfDay, t1From = timeRangeFrom.TimeOfDay,
                t1To = timeRangeTo.TimeOfDay;

            // if the time from is smaller than the time to, just filter by range
            if (t1From <= t1To)
            {
                return time >= t1From && time <= t1To;
            }

            // time from is greater than time to so two time intervals have to be created: one {timeFrom-12AM) and another one {12AM to timeTo}
            TimeSpan t2From = TimeSpan.MinValue, t2To = t1To;
            t1To = TimeSpan.MaxValue;

            return (time >= t1From && time <= t1To) || (time >= t2From && time <= t2To);
        }

    }
}
