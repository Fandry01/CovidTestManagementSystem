using CovidTestManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Models
{
    public class TestRecord
    {

        // Properties
        public int Id { get; set; }
        public bool ToLab { get; set; }
        public DateTime TestTimeslot { get; set; }

        [ForeignKey("PatientId")]
        public string PatientId { get; set; }
        [ForeignKey("AppointmentId")]
        public int  AppointmentId { get; set; }
        [ForeignKey("NurseId")]
        public int NurseId { get; set; }
        [ForeignKey("TestTypeId")]
        public int TestTypeId { get; set; }

        // Navigation methods
        public Person Patient { get; set; }
        public Nurse Nurse { get; set; }
        public TestTypes TestType { get; set; }
        
        public TestAppointment TestAppointment { get; set; }

        // Conversion methods of enum properties
        public ReportStatusEnum ReportStatus { get; set; }

        public int ReportStatusId
        {
            get { return (int)ReportStatus; }
            set { ReportStatus = (ReportStatusEnum)value; }
        }
        public TestResultEnum TestResult;
        public int TestResultId
        {
            get { return (int)TestResult; }
            set { TestResult = (TestResultEnum)value; }
        }

    }
}