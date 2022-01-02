using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Models
{
    public class TestTypeVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Test Type")]
        public string Name { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }
}
