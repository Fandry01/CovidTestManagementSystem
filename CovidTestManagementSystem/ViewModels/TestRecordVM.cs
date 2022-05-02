using CovidTestManagementSystem.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Models
{
    public class TestRecordVM
    {
        public int Id { get; set; }
        public TestRecord TestRecord { get; set; }
        public IEnumerable<SelectListItem> Nurses { get; set; }
        public List<TestTypes> TestTypes { get; set; }
        public ReportStatusEnum reportStatus { get; set; }
        public IEnumerable<SelectListItem> ReportStatuses { get; set; }
        public IEnumerable<SelectListItem> TestResults { get; set; }
    }

    public class PatientTestRecordVM
    {
        public List<TestRecord> TestRecords { get; set; }
    }



    public class AdminTestRecordVM 
    {
        public int TotalTestRequests { get; set; }
        public int CovidPositive { get; set; }
        public int CovidNegative { get; set; }
        public int PendingTest { get; set; }
        public List<TestRecord> TestRecords { get; set; }
        public List<TestAppointment> TestAppointments { get; set; }
    }


}
