using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Models
{
    public class TestTypes
    {
        [Key]
        public int Id { get; set; } // 2, 5, 7, 10, 100
        public string Name { get; set; }
        public  DateTime DateCreated { get; set; }

    }
}
