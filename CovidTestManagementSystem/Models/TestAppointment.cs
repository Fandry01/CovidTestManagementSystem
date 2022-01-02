using CovidTestManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Models
{
    public class TestAppointment
    {
        [Key]
        public int? Id { get; set; }
        public DateTime AppointmentTime { get; set; }
        [ForeignKey("PatientId")]
        public virtual Person Patient { get; set; }
        public string PatientId { get; set; }

        [ForeignKey("TestTypeId")]
        public virtual TestTypes TestType { get; set; }
        public int? TestTypeId { get; set; }
        [ForeignKey("TestRecord")]
        public int? TestRecordId { get; set; }
        public virtual TestRecord TestRecord { get; set; }
    }



}
