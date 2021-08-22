using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Data
{
    public class Nurse
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Employeeid { get; set; }
    }
}
