using CovidTestManagementSystem.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CovidTestManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using CovidTestManagementSystem.Enums;

namespace CovidTestManagementSystem.Controllers
{
    public class TestRecordController : Controller
    {
        
        private readonly ITestAppointRepository _appointmentRepo;
        private readonly INursesRepository _nursesrepo;
        private readonly ITestRecordRepository _testRecordRepository;

        public TestRecordController(
            ITestAppointRepository p_appointmentRepo, 
            INursesRepository p_nursesRepo, 
            ITestRecordRepository p_testRecordRepo)
        {
            _appointmentRepo = p_appointmentRepo;
            _nursesrepo = p_nursesRepo;
            _testRecordRepository = p_testRecordRepo;
        }

        // GET: TestRecordController
        public ActionResult Index()
        {
            var listOfTestRecords = _testRecordRepository.FindAll();
            return View(listOfTestRecords);
        }

        // GET: TestRecordController/Details/5
        public ActionResult Details(int id)
        {
            var testrecord = _testRecordRepository.FindById(id);
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

            // Itereren over enum en collecteren alle ints
            var listOfReportStatus = new List<int>();
            foreach(int i in Enum.GetValues(typeof(ReportStatusEnum)))
            {
                listOfReportStatus.Add(i); //  0, 1, 2, 3, 4
            }

            // Select all values en maken er een nieuwe selectlist van met custom properties (Text, Value)
            var selectListOfReportStatus = listOfReportStatus.Select(q => new SelectListItem
            {
                Text = Enum.GetName(typeof(ReportStatusEnum), q),
                Value = q.ToString()
            });

            var listOfTestResult = new List<int>();
            foreach (int i in Enum.GetValues(typeof(TestResultEnum)))
            {
                listOfTestResult.Add(i); //  0, 1, 2, 3, 4
            }

            // Select all values en maken er een nieuwe selectlist van met custom properties (Text, Value)
            var selectListOfTestResult = listOfTestResult.Select(q => new SelectListItem
            {
                Text = Enum.GetName(typeof(TestResultEnum), q),
                Value = q.ToString()
            });

            var appointment = _appointmentRepo.FindById(appointmentId);
            if(appointmentId == 0)
            {
                return View();
            }
            

            var testRecordVM = new TestRecordVM();
            testRecordVM.ReportStatuses = selectListOfReportStatus;
            testRecordVM.TestResults = selectListOfTestResult;
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
                // Create Test Record
                var testRecord = new TestRecord();
                testRecord.NurseId = vm.TestRecord.NurseId;
                testRecord.PatientId = vm.TestRecord.TestAppointment.PatientId;
                testRecord.ToLab = vm.TestRecord.ToLab;
                testRecord.ReportStatusId = (int)SetReportStatus(testRecord);
                testRecord.TestResultId = vm.TestRecord.TestResultId;
                testRecord.TestTimeslot = DateTime.Now;

                if (vm.TestRecord.TestAppointment != null)
                {
                    testRecord.AppointmentId = (int)vm.TestRecord.TestAppointment.Id;
                    testRecord.TestTypeId = (int)vm.TestRecord.TestAppointment.TestTypeId;
                }
                else
                {
                    throw new ArgumentNullException("Appointment ID is null, this value cannot be null");
                }

                // Update of Test Appointment
                var testAppointment = _appointmentRepo.FindById((int)vm.TestRecord.TestAppointment.Id);
                testAppointment.TestRecord = testRecord;

                _testRecordRepository.Create(testRecord);
                _appointmentRepo.Update(testAppointment);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                
                throw new Exception(ex.Message);
            
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
            var testRecord = _testRecordRepository.FindById(id);
            if (testRecord == null)
            {
                return NotFound();
            }
            var isSucces = _testRecordRepository.Delete(testRecord);
            if (!isSucces)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: TestRecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TestRecordVM model)
        {
            try
            {
                var testRecord = _testRecordRepository.FindById(id);
                if (testRecord == null)
                {
                    return NotFound();
                }
                var isSucces = _testRecordRepository.Delete(testRecord);
                if (!isSucces)
                {
                    return BadRequest();
                }
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
