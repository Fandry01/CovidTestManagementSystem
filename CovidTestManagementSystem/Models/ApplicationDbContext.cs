using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CovidTestManagementSystem.Models;
using CovidTestManagementSystem.ViewModels;
using System.Linq;

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
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<TestAppointment>()
               .HasOne(c => c.TestRecord)
               .WithOne(e => e.TestAppointment)
               .OnDelete(DeleteBehavior.SetNull);
               
        }
       


        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TestTypes> TestTypes { get; set; }
        public DbSet<TestRecord> TestRecords { get; set; }
        public DbSet<TestAppointment> TestAppointments { get; set; }
    }

}