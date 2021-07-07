using Acme_Salary_Payment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme_Salary_Payment.Tests
{
    public class TestDataBase
    {
        protected AcmeContext BuildContext(string nombreDB)
        {
            var options = new DbContextOptionsBuilder<AcmeContext>()
                .UseInMemoryDatabase(nombreDB).Options;

            var dbContext = new AcmeContext(options);
            return dbContext;
        }

    }
}
