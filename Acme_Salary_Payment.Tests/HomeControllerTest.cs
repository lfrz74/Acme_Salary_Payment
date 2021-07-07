using Acme_Salary_Payment.Controllers;
using Acme_Salary_Payment.DTO;
using Acme_Salary_Payment.Interfaces;
using Acme_Salary_Payment.Models;
using Acme_Salary_Payment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Acme_Salary_Payment.Tests
{
    [TestClass]
    public class HomeControllerTest: TestDataBase
    {
        private readonly IReadFileService _readFileService = new ReadFileService();
        private readonly ICalculateSalaryService _calculateSalaryService = new CalculateSalaryService();

        [TestMethod]
        public async Task Given_a_number_of_employees_return_the_same_number_of_records()
        {
            //Setup Inmemory DB
            var dbName = Guid.NewGuid().ToString();
            var dbContext = BuildContext(dbName);
            //Insert data in table DayRates
            InsertDataInDayRates(dbContext);
            await dbContext.SaveChangesAsync();

            //Controller
            var controller = new HomeController(_readFileService, dbContext, _calculateSalaryService);

            //Upload the file
            FormFile file1 = UploadFile(@"D:\temp\AcmeUpload1.txt");

            //test method
            var response = await controller.CalculateSalary(file1);
            var resp = ((ViewResult)response.Result).Model;
            Assert.AreEqual(3, ((List<EmployeeDTO>)resp).Count);
        }

        [TestMethod]
        public async Task Should_Calculate_Fine_the_Salaries_of_sent_employees()
        {
            //Setup Inmemory DB
            var dbName = Guid.NewGuid().ToString();
            var dbContext = BuildContext(dbName);
            //Insert data in table DayRates
            InsertDataInDayRates(dbContext);
            await dbContext.SaveChangesAsync();

            //Controller
            var controller = new HomeController(_readFileService, dbContext, _calculateSalaryService);

            //Upload the file
            FormFile file1 = UploadFile(@"D:\temp\AcmeUpload1.txt");

            //test method
            var response = await controller.CalculateSalary(file1);
            var resp = ((ViewResult)response.Result).Model;
            var list_emp = (List<EmployeeDTO>)resp;
            Assert.AreEqual(219m, list_emp[0].Amount);
            Assert.AreEqual(89m, list_emp[1].Amount);
            Assert.AreEqual(239.3333m, Math.Round(list_emp[2].Amount, 4));
        }

        [TestMethod]
        public async Task Given_An_Empty_File_Return_Exception()
        {
            //Setup Inmemory DB
            var dbName = Guid.NewGuid().ToString();
            var dbContext = BuildContext(dbName);
            //Insert data in table DayRates
            InsertDataInDayRates(dbContext);
            await dbContext.SaveChangesAsync();

            //Controller
            var controller = new HomeController(_readFileService, dbContext, _calculateSalaryService);

            //Upload the file
            FormFile file1 = UploadFile(@"D:\temp\AcmeUpload0.txt");

            //test method
            var response = await controller.CalculateSalary(file1);
            Assert.AreEqual(500, ((ObjectResult)response.Result).StatusCode);
        }

        [TestMethod]
        public async Task Given_An_Malformed_file_Exception()
        {
            //Setup Inmemory DB
            var dbName = Guid.NewGuid().ToString();
            var dbContext = BuildContext(dbName);
            //Insert data in table DayRates
            InsertDataInDayRates(dbContext);
            await dbContext.SaveChangesAsync();

            //Controller
            var controller = new HomeController(_readFileService, dbContext, _calculateSalaryService);

            //Upload the file
            FormFile file1 = UploadFile(@"D:\temp\AcmeUpload2.txt");

            //test method
            var response = await controller.CalculateSalary(file1);
            Assert.AreEqual(500, ((ObjectResult)response.Result).StatusCode);
        }


        #region Utilitarian Methods
        private FormFile UploadFile(string path)
        {
            var stream = File.OpenRead(path);
            char quotation = '"';
            string contentDisposition =
                "form-data; name=" + quotation +
                "file_info" + quotation + ";filename=" +
                quotation + Path.GetFileName(stream.Name) + quotation;

            var file1 = new FormFile(stream, 0, stream.Length, "file_info", Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
                ContentDisposition = contentDisposition,
                ContentType = "text/plain"
            };
            return file1;
        }

        private void InsertDataInDayRates(Data.AcmeContext dbContext)
        {
            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 1,
                    code_day = "MO",
                    hour_from = new DateTime(1900, 1, 1, 0, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 9, 0, 0),
                    rate = 25.0m,
                    order = 1
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 2,
                    code_day = "MO",
                    hour_from = new DateTime(1900, 1, 1, 9, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 18, 0, 0),
                    rate = 17.0m,
                    order = 2
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 3,
                    code_day = "MO",
                    hour_from = new DateTime(1900, 1, 1, 18, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 0, 0, 0),
                    rate = 20.0m,
                    order = 3
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 4,
                    code_day = "TU",
                    hour_from = new DateTime(1900, 1, 1, 0, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 9, 0, 0),
                    rate = 25.0m,
                    order = 1
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 5,
                    code_day = "TU",
                    hour_from = new DateTime(1900, 1, 1, 9, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 18, 0, 0),
                    rate = 15.0m,
                    order = 2
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 6,
                    code_day = "TU",
                    hour_from = new DateTime(1900, 1, 1, 18, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 0, 0, 0),
                    rate = 20.0m,
                    order = 3
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 7,
                    code_day = "WE",
                    hour_from = new DateTime(1900, 1, 1, 0, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 9, 0, 0),
                    rate = 25.0m,
                    order = 1
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 8,
                    code_day = "WE",
                    hour_from = new DateTime(1900, 1, 1, 9, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 18, 0, 0),
                    rate = 15.0m,
                    order = 2
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 9,
                    code_day = "WE",
                    hour_from = new DateTime(1900, 1, 1, 18, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 0, 0, 0),
                    rate = 20.0m,
                    order = 3
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 10,
                    code_day = "TH",
                    hour_from = new DateTime(1900, 1, 1, 0, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 9, 0, 0),
                    rate = 25.0m,
                    order = 1
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 11,
                    code_day = "TH",
                    hour_from = new DateTime(1900, 1, 1, 9, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 18, 0, 0),
                    rate = 15.0m,
                    order = 2
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 12,
                    code_day = "TH",
                    hour_from = new DateTime(1900, 1, 1, 18, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 0, 0, 0),
                    rate = 20.0m,
                    order = 3
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 13,
                    code_day = "FR",
                    hour_from = new DateTime(1900, 1, 1, 0, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 9, 0, 0),
                    rate = 25.0m,
                    order = 1
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 14,
                    code_day = "FR",
                    hour_from = new DateTime(1900, 1, 1, 9, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 18, 0, 0),
                    rate = 15.0m,
                    order = 2
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 15,
                    code_day = "FR",
                    hour_from = new DateTime(1900, 1, 1, 18, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 0, 0, 0),
                    rate = 20.0m,
                    order = 3
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 16,
                    code_day = "SA",
                    hour_from = new DateTime(1900, 1, 1, 0, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 9, 0, 0),
                    rate = 30.0m,
                    order = 1
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 17,
                    code_day = "SA",
                    hour_from = new DateTime(1900, 1, 1, 9, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 18, 0, 0),
                    rate = 20.0m,
                    order = 2
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 18,
                    code_day = "SA",
                    hour_from = new DateTime(1900, 1, 1, 18, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 0, 0, 0),
                    rate = 25.0m,
                    order = 3
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 19,
                    code_day = "SU",
                    hour_from = new DateTime(1900, 1, 1, 0, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 9, 0, 0),
                    rate = 30.0m,
                    order = 1
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 20,
                    code_day = "SU",
                    hour_from = new DateTime(1900, 1, 1, 9, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 18, 0, 0),
                    rate = 20.0m,
                    order = 2
                });

            dbContext.DayRates.Add(
                new DayRate
                {
                    id = 21,
                    code_day = "SU",
                    hour_from = new DateTime(1900, 1, 1, 18, 1, 0),
                    hour_to = new DateTime(1900, 1, 1, 0, 0, 0),
                    rate = 25.0m,
                    order = 3
                });
        }
        #endregion
    }
}
