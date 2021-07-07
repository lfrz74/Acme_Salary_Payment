﻿// <auto-generated />
using System;
using Acme_Salary_Payment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Acme_Salary_Payment.Migrations
{
    [DbContext(typeof(AcmeContext))]
    partial class AcmeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Acme_Salary_Payment.Models.DayRate", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code_day")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.Property<DateTime>("hour_from")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("hour_to")
                        .HasColumnType("datetime");

                    b.Property<int>("order")
                        .HasColumnType("int");

                    b.Property<decimal>("rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("DayRates");

                    b.HasData(
                        new
                        {
                            id = 1,
                            code_day = "MO",
                            hour_from = new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 1,
                            rate = 25.0m
                        },
                        new
                        {
                            id = 2,
                            code_day = "MO",
                            hour_from = new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 2,
                            rate = 15.0m
                        },
                        new
                        {
                            id = 3,
                            code_day = "MO",
                            hour_from = new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 3,
                            rate = 20.0m
                        },
                        new
                        {
                            id = 4,
                            code_day = "TU",
                            hour_from = new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 1,
                            rate = 25.0m
                        },
                        new
                        {
                            id = 5,
                            code_day = "TU",
                            hour_from = new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 2,
                            rate = 15.0m
                        },
                        new
                        {
                            id = 6,
                            code_day = "TU",
                            hour_from = new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 3,
                            rate = 20.0m
                        },
                        new
                        {
                            id = 7,
                            code_day = "WE",
                            hour_from = new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 1,
                            rate = 25.0m
                        },
                        new
                        {
                            id = 8,
                            code_day = "WE",
                            hour_from = new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 2,
                            rate = 15.0m
                        },
                        new
                        {
                            id = 9,
                            code_day = "WE",
                            hour_from = new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 3,
                            rate = 20.0m
                        },
                        new
                        {
                            id = 10,
                            code_day = "TH",
                            hour_from = new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 1,
                            rate = 25.0m
                        },
                        new
                        {
                            id = 11,
                            code_day = "TH",
                            hour_from = new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 2,
                            rate = 15.0m
                        },
                        new
                        {
                            id = 12,
                            code_day = "TH",
                            hour_from = new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 3,
                            rate = 20.0m
                        },
                        new
                        {
                            id = 13,
                            code_day = "FR",
                            hour_from = new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 1,
                            rate = 25.0m
                        },
                        new
                        {
                            id = 14,
                            code_day = "FR",
                            hour_from = new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 2,
                            rate = 15.0m
                        },
                        new
                        {
                            id = 15,
                            code_day = "FR",
                            hour_from = new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 3,
                            rate = 20.0m
                        },
                        new
                        {
                            id = 16,
                            code_day = "SA",
                            hour_from = new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 1,
                            rate = 30.0m
                        },
                        new
                        {
                            id = 17,
                            code_day = "SA",
                            hour_from = new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 2,
                            rate = 20.0m
                        },
                        new
                        {
                            id = 18,
                            code_day = "SA",
                            hour_from = new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 3,
                            rate = 25.0m
                        },
                        new
                        {
                            id = 19,
                            code_day = "SU",
                            hour_from = new DateTime(1900, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 1,
                            rate = 30.0m
                        },
                        new
                        {
                            id = 20,
                            code_day = "SU",
                            hour_from = new DateTime(1900, 1, 1, 9, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 2,
                            rate = 20.0m
                        },
                        new
                        {
                            id = 21,
                            code_day = "SU",
                            hour_from = new DateTime(1900, 1, 1, 18, 1, 0, 0, DateTimeKind.Unspecified),
                            hour_to = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            order = 3,
                            rate = 25.0m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
