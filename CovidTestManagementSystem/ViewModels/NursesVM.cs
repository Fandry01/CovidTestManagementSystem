using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Models
{
    public class NursesVM
    {
        public int Id { get; set; }
        [Display(Name = "Nurse Name")]
        public string Name { get; set; }
        [Display(Name = "Employee ID")]
        public string Employeeid { get; set; }
    }
}
