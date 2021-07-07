using Acme_Salary_Payment.Data;
using Acme_Salary_Payment.DTO;
using Acme_Salary_Payment.Interfaces;
using Acme_Salary_Payment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Acme_Salary_Payment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadFileService _readFileService;
        private readonly ICalculateSalaryService _calculateSalaryService;
        private readonly AcmeContext _acmeContext;

        public HomeController(
            IReadFileService readFileService,
            AcmeContext acmeContext,
            ICalculateSalaryService calculateSalaryService)
        {
            _readFileService = readFileService;
            _calculateSalaryService = calculateSalaryService;
            _acmeContext = acmeContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }

        /// <summary>
        /// Receive the file and calculate the salary of all sent employees
        /// </summary>
        /// <param name="file_info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<EmployeeDTO>>> CalculateSalary(IFormFile file_info)
        {
            List<EmployeeDTO> listEmployee;
            try
            {
                if (file_info == null || file_info.Length == 0)
                    throw new Exception("The file wasn't selected or it's empty!");
                //Reading the file
                var res = await _readFileService.ReadAsStringAsync(file_info);
                //Extracting the rates from the DB, just once
                var list_rates = await _acmeContext.DayRates.ToListAsync();
                //Processing the file
                listEmployee = 
                    await _calculateSalaryService.CalculateEmployeeSalary(res, list_rates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return View(listEmployee);
        }
    }
}
