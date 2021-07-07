using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme_Salary_Payment.Interfaces
{
    public interface IReadFileService
    {
        Task<List<string>> ReadAsStringAsync(IFormFile file);
    }
}
