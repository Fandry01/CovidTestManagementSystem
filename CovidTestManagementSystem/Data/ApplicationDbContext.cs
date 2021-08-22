using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CovidTestManagementSystem.Models;

namespace CovidTestManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<TestTypes> TestTypes { get; set; }
        public DbSet<TestRecord>TestRecords { get; set; }
        public DbSet<CovidTestManagementSystem.Models.TestTypeVM> TestTypeVM { get; set; }
        public DbSet<CovidTestManagementSystem.Models.NursesVM> NursesVM { get; set; }
    }
}
