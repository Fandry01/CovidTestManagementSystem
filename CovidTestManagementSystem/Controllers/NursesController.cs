using AutoMapper;
using CovidTestManagementSystem.Contracts;
using CovidTestManagementSystem.Models;
using CovidTestManagementSystem.Models;
using CovidTestManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTestManagementSystem.Controllers
{
    public class NursesController : Controller
    {
        private readonly INursesRepository _repo;
        private readonly IMapper _mapper;
        public NursesController(INursesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: NursesController
        public ActionResult Index()
        {
            var nurses = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Nurse>, List<NursesVM>>(nurses);
            return View(model);
        }

        // GET: NursesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound(); 
            }
            var nurse = _repo.FindById(id);
            var model = _mapper.Map<NursesVM>(nurse);
            return View(model);
        }

        // GET: NursesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nurse model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var nurse = _mapper.Map<NursesVM>(model);

                var isSucces = _repo.Create(model);
                if (!isSucces)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model)
;;                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
                
            }
        }

        // GET: NursesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var nurse = _repo.FindById(id);
            var model = _mapper.Map<NursesVM>(nurse);
            return View(model);
        }

        // POST: NursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NursesVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var nurse = _mapper.Map<Nurse>(model);
                var isSucces = _repo.Update(nurse);
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

        // GET: NursesController/Delete/5
        public ActionResult Delete(int id)
        {
            var nurse = _repo.FindById(id);
            if (nurse == null)
            {
                return NotFound();
            }
            var isSucces = _repo.Delete(nurse);
            if (!isSucces)
            {
                return BadRequest();
            }

            return View();
        }

        // POST: NursesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var nurse = _repo.FindById(id);
                
                    if (nurse == null)
                    {
                        return NotFound();
                    }
                var isSucces = _repo.Delete(nurse);
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
