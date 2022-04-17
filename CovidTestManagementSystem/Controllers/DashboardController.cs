using AutoMapper;
using CovidTestManagementSystem.Contracts;
using CovidTestManagementSystem.Enums;
using CovidTestManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CovidTestManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<Person> _userManager;
        private readonly IPersonRepository _userRepository;
        private readonly ITestRecordRepository _testRepository;
        private readonly ITestAppointRepository _testAppointRepository;
        private readonly IMapper _mapper; 
        public DashboardController(UserManager<Person> userManager, 
            IPersonRepository userRepository, 
            ITestRecordRepository testRepository, 
            ITestAppointRepository testAppointRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _testRepository = testRepository;
            _testAppointRepository = testAppointRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                return RedirectToAction("MyAdmin", "Dashboard");
            }
            else if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            PatientDashboardVM vm = new PatientDashboardVM();

            Person loggedInUser = _userManager.GetUserAsync(User).Result;
            Person person = _userRepository.FindByIdString(loggedInUser.Id);
         
            person.TestRecords = _testRepository.GetTestRecordsByPerson(person.Id);
           
            vm.Patient = person;
            
            
            

            return View(vm);
        }

        public IActionResult MyAdmin()
        {
            var testRecords = _testRepository.FindAll();
            var testAppointments = _testAppointRepository.FindAll().Where(p => p.TestRecord == null);

            AdminTestRecordVM vm = new AdminTestRecordVM()
            {           
                TestAppointments = testAppointments.ToList(),
                TestRecords = testRecords.ToList(),
                PendingTest = testRecords.Where(p => p.TestResult == null).Count(),
                TotalTestRequests = testAppointments.Count(),
                CovidNegative = testRecords.Where(p => p.TestResult == TestResultEnum.Negative).Count(),
                CovidPositive = testRecords.Where(p => p.TestResult == TestResultEnum.Postive).Count()
            };

            return View(vm);
        }
        public ActionResult Edit(int id)
        {
            if (!_testRepository.IsExists(id))
            {
                return NotFound();
            }
            var testrecord = _testRepository.FindById(id);
            var model = _mapper.Map<TestRecordVM>(testrecord);
            return View(model);
        }

        // POST: TestAppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestRecordVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var testrecord = model.TestRecord;
                var isSucces = _testRepository.Update(testrecord);
                if (!isSucces)
                {
                    ModelState.AddModelError("", "Something Went Wrong");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong");
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {
            var testrecord = _testRepository.FindById(id);
            var model = _mapper.Map<DetailsTestRecordVM>(testrecord);
            return View(model);
        }



            /*public IActionResult MyTest()
            {
                var patient = _userManager.GetUserAsync(User);
                var patientid = patient.Id.ToString();
                var patientrequest = _testRepository.GetTestRecordsByPerson(patientid);

                var patientmodel = _mapper.Map<List<TestRecordVM>>(patientrequest);

                var model = new PatientTestRecordVM
                {
                    TestRecords = patientmodel
                };

                return View(model);
            }*/
        }
}
