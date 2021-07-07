using Acme_Salary_Payment.DTO;
using Acme_Salary_Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme_Salary_Payment.Interfaces
{
    public interface ICalculateSalaryService
    {
        Task<List<EmployeeDTO>> CalculateEmployeeSalary(List<string> listEmp, List<DayRate> list_rates);
    }
}
