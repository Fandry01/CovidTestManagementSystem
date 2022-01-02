using CovidTestManagementSystem.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CovidTestManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using CovidTestManagementSystem.Enum;

namespace CovidTestManagementSystem.Controllers
{
    public class TestRecordController : Controller
    {
        
        private readonly ITestAppointRepository _appointmentRepo;
        private readonly INursesRepository _nursesrepo;

        public TestRecordController(ITestAppointRepository p_appointmentRepo,  INursesRepository p_nursesRepo)
        {
            _appointmentRepo = p_appointmentRepo;
            _nursesrepo = p_nursesRepo;
        }

        // GET: TestRecordController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestRecordController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestRecordController/Create
        public ActionResult Create(int appointmentId)
        {
            var nurses = _nursesrepo.FindAll();
            var SelectListOfNurses = nurses.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
             

            var appointment = _appointmentRepo.FindById(appointmentId);
            if(appointmentId == 0)
            {
                return View();
            }
            

            var testRecordVM = new TestRecordVM();
            testRecordVM.TestRecord = new TestRecord()
            {
                TestAppointment = appointment,
                
            };
            testRecordVM.Nurses = SelectListOfNurses;
           


            return View(testRecordVM);
        }

        // POST: TestRecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestRecordVM vm)
        {
            try
            {

                var testrecord = new TestRecord();
                testrecord.ReportStatus = vm.TestRecord.ReportStatus;
                testrecord.NurseId = vm.TestRecord.NurseId;
                testrecord.ToLab = vm.TestRecord.ToLab;
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: TestRecordController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestRecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestRecordController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestRecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //private methods
        private ReportStatusEnum SetReportStatus(TestRecord testRecord)
        {
            if (testRecord.NurseId == 0)
            {
                return ReportStatusEnum.Unassigned;
            }
            else if (testRecord.ToLab == false)
            {
                return ReportStatusEnum.Assigned;
            }
            else if (testRecord.ToLab == true && testRecord.TestResult == TestResultEnum.Tobetested)
            {
                return ReportStatusEnum.Analyzed;
            }
            else if (testRecord.TestResult == TestResultEnum.Postive || testRecord.TestResult == TestResultEnum.Negative)
            {
                return ReportStatusEnum.Finished;
            }

            return ReportStatusEnum.Default;
        }
    }
}
