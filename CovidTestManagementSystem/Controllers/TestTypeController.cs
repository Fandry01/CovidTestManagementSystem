using AutoMapper;
using CovidTestManagementSystem.Contracts;
using CovidTestManagementSystem.Models;
using CovidTestManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Controllers
{
    public class TestTypeController : Controller
    {
        private readonly ITestTypeRepository _repo;
        private readonly IMapper _mapper;

        public TestTypeController(ITestTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: TestTypeController
        public ActionResult Index()
        {
            var testType = _repo.FindAll().ToList();
            var model = _mapper.Map<List<TestTypes>, List<TestTypeVM>>(testType);
            return View(model);
        }

        // GET: TestTypeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            
            var testType = _repo.FindById(id);
            var model = _mapper.Map<TestTypeVM>(testType);

            return View(model);
        }

        // GET: TestTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestTypes model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var TestType = _mapper.Map<TestTypeVM>(model);
                TestType.DateCreated = DateTime.Now;


                var isSucces = _repo.Create(model);
                if (!isSucces)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: TestTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var testType = _repo.FindById(id);
            var model = _mapper.Map<TestTypeVM>(testType);
            return View(model);
        }

        // POST: TestTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var testType = _mapper.Map<TestTypes>(model);

                var isSucces = _repo.Update(testType);
                if (!isSucces)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: TestTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var testType = _repo.FindById(id);
            if (testType == null)
            {
                return NotFound();
            }
            var isSucces = _repo.Delete(testType);
            if (!isSucces)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: TestTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TestTypeVM model)
        {
            try
            {
                var testType = _repo.FindById(id);
                if (testType == null)
                {
                    return NotFound();
                }
                var isSucces = _repo.Delete(testType);
                if (!isSucces)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
