using Acme_Salary_Payment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme_Salary_Payment.Data
{
    public class AcmeContext: DbContext
    {
        public AcmeContext(DbContextOptions<AcmeContext> dbContext) :
            base(dbContext)
        {

        }

        public DbSet<DayRate> DayRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Inserting data for calculating  the hourly rate
            modelBuilder.Entity<DayRate>().HasData(
                new DayRate[] {
                    new DayRate{
                        id=1, code_day="MO", hour_from=new DateTime(1900, 1, 1, 0, 1, 0), hour_to=new DateTime(1900, 1, 1, 9, 0, 0), rate=25.0m, order=1 },
                    new DayRate{
                        id=2, code_day="MO", hour_from=new DateTime(1900, 1, 1, 9, 1, 0), hour_to=new DateTime(1900, 1, 1, 18, 0, 0), rate=15.0m, order=2 },
                    new DayRate{
                        id=3, code_day="MO", hour_from=new DateTime(1900, 1, 1, 18, 1, 0), hour_to=new DateTime(1900, 1, 1, 0, 0, 0), rate=20.0m, order=3 },
                    new DayRate{
                        id=4, code_day="TU", hour_from=new DateTime(1900, 1, 1, 0, 1, 0), hour_to=new DateTime(1900, 1, 1, 9, 0, 0), rate=25.0m, order=1 },
                    new DayRate{
                        id=5, code_day="TU", hour_from=new DateTime(1900, 1, 1, 9, 1, 0), hour_to=new DateTime(1900, 1, 1, 18, 0, 0), rate=15.0m, order=2 },
                    new DayRate{
                        id=6, code_day="TU", hour_from=new DateTime(1900, 1, 1, 18, 1, 0), hour_to=new DateTime(1900, 1, 1, 0, 0, 0), rate=20.0m, order=3 },                    
                    new DayRate{
                        id=7, code_day="WE", hour_from=new DateTime(1900, 1, 1, 0, 1, 0), hour_to=new DateTime(1900, 1, 1, 9, 0, 0), rate=25.0m, order=1 },
                    new DayRate{
                        id=8, code_day="WE", hour_from=new DateTime(1900, 1, 1, 9, 1, 0), hour_to=new DateTime(1900, 1, 1, 18, 0, 0), rate=15.0m, order=2 },
                    new DayRate{
                        id=9, code_day="WE", hour_from=new DateTime(1900, 1, 1, 18, 1, 0), hour_to=new DateTime(1900, 1, 1, 0, 0, 0), rate=20.0m, order=3 },                    
                    new DayRate{
                        id=10, code_day="TH", hour_from=new DateTime(1900, 1, 1, 0, 1, 0), hour_to=new DateTime(1900, 1, 1, 9, 0, 0), rate=25.0m, order=1 },
                    new DayRate{
                        id=11, code_day="TH", hour_from=new DateTime(1900, 1, 1, 9, 1, 0), hour_to=new DateTime(1900, 1, 1, 18, 0, 0), rate=15.0m, order=2 },
                    new DayRate{
                        id=12, code_day="TH", hour_from=new DateTime(1900, 1, 1, 18, 1, 0), hour_to=new DateTime(1900, 1, 1, 0, 0, 0), rate=20.0m, order=3 },                    
                    new DayRate{
                        id=13, code_day="FR", hour_from=new DateTime(1900, 1, 1, 0, 1, 0), hour_to=new DateTime(1900, 1, 1, 9, 0, 0), rate=25.0m, order=1 },
                    new DayRate{
                        id=14, code_day="FR", hour_from=new DateTime(1900, 1, 1, 9, 1, 0), hour_to=new DateTime(1900, 1, 1, 18, 0, 0), rate=15.0m, order=2 },
                    new DayRate{
                        id=15, code_day="FR", hour_from=new DateTime(1900, 1, 1, 18, 1, 0), hour_to=new DateTime(1900, 1, 1, 0, 0, 0), rate=20.0m, order=3 },
                    new DayRate{
                        id=16, code_day="SA", hour_from=new DateTime(1900, 1, 1, 0, 1, 0), hour_to=new DateTime(1900, 1, 1, 9, 0, 0), rate=30.0m, order=1 },
                    new DayRate{
                        id=17, code_day="SA", hour_from=new DateTime(1900, 1, 1, 9, 1, 0), hour_to=new DateTime(1900, 1, 1, 18, 0, 0), rate=20.0m, order=2 },
                    new DayRate{
                        id=18, code_day="SA", hour_from=new DateTime(1900, 1, 1, 18, 1, 0), hour_to=new DateTime(1900, 1, 1, 0, 0, 0), rate=25.0m, order=3 },
                    new DayRate{
                        id=19, code_day="SU", hour_from=new DateTime(1900, 1, 1, 0, 1, 0), hour_to=new DateTime(1900, 1, 1, 9, 0, 0), rate=30.0m, order=1 },
                    new DayRate{
                        id=20, code_day="SU", hour_from=new DateTime(1900, 1, 1, 9, 1, 0), hour_to=new DateTime(1900, 1, 1, 18, 0, 0), rate=20.0m, order=2 },
                    new DayRate{
                        id=21, code_day="SU", hour_from=new DateTime(1900, 1, 1, 18, 1, 0), hour_to=new DateTime(1900, 1, 1, 0, 0, 0), rate=25.0m, order=3 },
            });
        }
    }
}
