using Acme_Salary_Payment.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Acme_Salary_Payment.Services
{
    public class ReadFileService : IReadFileService
    {
        public async Task<List<string>> ReadAsStringAsync(IFormFile file)
        {
            List<string> list_result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    list_result.Add(await reader.ReadLineAsync());
            }
            return list_result;
        }
    }
}
