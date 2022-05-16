using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER_API.Authontaction;
using ViewModels;

namespace Admin_MVC.Models.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unit;
        private readonly IModelRepository<Category> CatRepo;

        public CategoryController(IUnitOfWork _Unit)
        {
            unit = _Unit;
            CatRepo = unit.GetCategryRepo();
        }

        public IActionResult GetAll()
        {

            var data = CatRepo.GetAll().ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var data = CatRepo.GetById(Id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var data = CatRepo.GetAll();
            ViewBag.CategoryList = new SelectList(data.ToList(), "Id", "CatName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM c)
        {
            if (ModelState.IsValid)
            {
                CatRepo.Add(c.ToModel());
                await unit.Save();
                return RedirectToAction("GetAll");
            }
            var data = CatRepo.GetAll();
            ViewBag.CategoryList = new SelectList(data.ToList(), "Id", "CatName");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cat =  CatRepo.GetById(Id);
            var data = CatRepo.GetAll();
            ViewBag.CategoryList = new SelectList(data.ToList(), "Id", "CatName");
            return View(cat.ToViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id,CategoryVM c)
        {
            if (ModelState.IsValid)
            {
                CatRepo.Update(c.ToModel());
                await unit.Save();
                return RedirectToAction("GetAll");
            }
            var data = CatRepo.GetAll();
            ViewBag.CategoryList = new SelectList(data.ToList(), "Id", "CatName");
            return View();
        }

        public async Task< IActionResult> Delete(int Id)
        {
            var e =  CatRepo.GetById(Id);
             CatRepo.Remove(e);
            await unit.Save();
            return RedirectToAction("GetAll");
        }

    }
}
