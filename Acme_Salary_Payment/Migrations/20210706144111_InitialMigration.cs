using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme_Salary_Payment.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayRates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_day = table.Column<string>(type: "char(2)", nullable: false),
                    hour_from = table.Column<DateTime>(type: "datetime", nullable: false),
                    hour_to = table.Column<DateTime>(type: "datetime", nullable: false),
                    rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayRates", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "DayRates",
                columns: new[] { "id", "code_day", "hour_from", "hour_to", "order", "rate" },
                values: new object[,]
                {
                    { 1, "MO", new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 25.0m },
                    { 19, "SU", new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 30.0m },
                    { 18, "SA", new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 25.0m },
                    { 17, "SA", new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 20.0m },
                    { 16, "SA", new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 30.0m },
                    { 15, "FR", new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 20.0m },
                    { 14, "FR", new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 15.0m },
                    { 13, "FR", new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 25.0m },
                    { 12, "TH", new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 20.0m },
                    { 20, "SU", new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 20.0m },
                    { 11, "TH", new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 15.0m },
                    { 9, "WE", new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 20.0m },
                    { 8, "WE", new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 15.0m },
                    { 7, "WE", new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 25.0m },
                    { 6, "TU", new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 20.0m },
                    { 5, "TU", new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 15.0m },
                    { 4, "TU", new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 25.0m },
                    { 3, "MO", new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 20.0m },
                    { 2, "MO", new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 15.0m },
                    { 10, "TH", new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 25.0m },
                    { 21, "SU", new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 25.0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayRates");
        }
    }
}
