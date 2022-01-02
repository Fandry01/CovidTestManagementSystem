using CovidTestManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Models
{
    public class Person : IdentityUser
    {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Sofinummer { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<TestRecord> TestRecords { get; set; }
        public ICollection<TestAppointment> TestAppointments { get; set; }

    }
}
