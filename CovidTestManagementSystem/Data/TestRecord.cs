using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Data
{
    public class TestRecord
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PatientId")]
        public Patient Name { get; set; }
        public string PatientId { get; set; }
        public string ReportStatus { get; set; }
        [ForeignKey("TestTypeId")]
        public TestTypes TestTypes { get; set; }
        public int TestTypeId { get; set; }
        public DateTime TestTimeslot { get; set; }
        [ForeignKey("NurseId")]
        public Nurse nurses { get; set; }
        public int NursesId { get; set; }
        public string FinalReportStatus { get; set; }
    }
}
