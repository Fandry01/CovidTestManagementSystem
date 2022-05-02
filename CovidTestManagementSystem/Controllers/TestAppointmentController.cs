using AutoMapper;
using CovidTestManagementSystem.Contracts;
using CovidTestManagementSystem.Models;
using CovidTestManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CovidTestManagementSystem.Controllers
{
    public class TestAppointmentController : Controller
    {
        private readonly ITestAppointRepository _repo;
        private readonly ITestTypeRepository _testTypeRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Person> _userManager;
        public TestAppointmentController(ITestAppointRepository repo, IMapper mapper, ITestTypeRepository testTypeRepo, UserManager<Person> userManager)
        {
            _mapper = mapper;
            _repo = repo;
            _testTypeRepo = testTypeRepo;
            _userManager = userManager;

        }
        // GET: TestAppointmentController
        public ActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var appointments = _repo.FindAllByUser(user.Id).ToList();
            var model = _mapper.Map<List<TestAppointment>, List<TestAppointmentVM>>(appointments);
            return View(model);
        }

        // GET: TestAppointmentController/Details/5
        public ActionResult Details(int id)
        {
            var appointmentDetail = _repo.FindById(id);
            var model = _mapper.Map<TestAppointmentVM>(appointmentDetail);
            return View(model);
        }

        // GET: TestAppointmentController/Create
        public ActionResult Create()
        {
            var testTypes = _testTypeRepo.FindAll();
            var testTypesItem = testTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var model = new CreateTestAppointmentVM
            {
                TestType = testTypesItem
            };
            return View(model);
        }

        // POST: TestAppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTestAppointmentVM model)
        {
            try
            {
                var testTypes = _testTypeRepo.FindAll();
                var testTypesItem = testTypes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString(),
                    Selected = true
                });
                model.TestType = testTypesItem.ToList();
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var patient = _userManager.GetUserAsync(User).Result;

                var isSucces = _repo.Create(new TestAppointment
                {
                    PatientId = patient.Id,
                    AppointmentTime = model.AppointmentTime,
                    TestTypeId = model.TestTypeId,
                    TestRecordId = null
                });

                if (!isSucces)
                {
                    ModelState.AddModelError("", "Something went wrong with submitting your record");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: TestAppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var testappoint = _repo.FindById(id);
            var model = _mapper.Map<EditTestAppointmentVM>(testappoint);
            return View(model);
        }

        // POST: TestAppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditTestAppointmentVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var appointment = _repo.FindById(model.Id);
                var isSucces = _repo.Update(appointment);
                if (!isSucces)
                {
                    ModelState.AddModelError("", "Error While Saving");
                    return View(model);
                }
                return RedirectToAction(nameof(Details), new {id = model.Id }) ;
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }

        // GET: TestAppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var testAppointment = _repo.FindById(id);
            if (testAppointment == null)
            {
                return NotFound();
            }
            var isSucces = _repo.Delete(testAppointment);
            if (!isSucces)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));

        }

        // POST: TestAppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TestAppointmentVM model)
        {
            try
            {
                var testAppointment = _repo.FindById(id);
                if (testAppointment == null)
                {
                    return NotFound();
                }
                var isSucces = _repo.Delete(testAppointment);
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
    }
}
