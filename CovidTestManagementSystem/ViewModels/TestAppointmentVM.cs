using CovidTestManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.ViewModels
{
    public class TestAppointmentVM
    {

        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
        public virtual Person Patient { get; set; }
        public string PatientId { get; set; }
        public virtual Nurse Nurse { get; set; }
        public int? NurseId { get; set; }
        public virtual TestTypes TestType { get; set; }
        public int? TestTypeId { get; set; }
        public virtual TestRecord TestRecord { get; set; }
        public int? TestRecordId { get; set; }

    }



    public class CreateTestAppointmentVM
    {
        [Required]
        public DateTime AppointmentTime { get; set; }
        public IEnumerable<SelectListItem> TestType { get; set; }
        public int TestTypeId { get; set; }
    }

    public class EditTestAppointmentVM
    {
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
    }


}
