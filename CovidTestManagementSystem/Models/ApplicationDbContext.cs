using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CovidTestManagementSystem.Models;
using CovidTestManagementSystem.ViewModels;

namespace CovidTestManagementSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestTypes>()
                 .HasMany<TestAppointment>()
                 .WithOne(e => e.TestType)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();
        }

        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Person> Persons{ get; set; }
        public DbSet<TestTypes> TestTypes { get; set; }
        public DbSet<TestRecord>TestRecords { get; set; }
        public DbSet<TestAppointment> TestAppointments { get; set; } 
        public DbSet<CovidTestManagementSystem.ViewModels.TestAppointmentVM> TestAppointmentVM { get; set; }
        public DbSet<CovidTestManagementSystem.Models.DetailsTestRecordVM> DetailsTestRecordVM { get; set; }
       
    }
}
