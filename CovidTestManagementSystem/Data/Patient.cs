using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Data
{
    public class Patient : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string EmailAddres { get; set; }
        public string Telnummer { get; set; }
        public string Sofinummer { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
