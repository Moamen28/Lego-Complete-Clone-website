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

namespace Admin_MVC.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class FilterOptionController : Controller
    {
        private readonly IUnitOfWork unit;
        private readonly IModelRepository<Filter> FilterRepo;
        private readonly IModelRepository<FilterOption> FilterOptionRepo;
        public FilterOptionController(IUnitOfWork _unit)
        {
            unit = _unit;
            FilterRepo = unit.GetFilterRepo();
            FilterOptionRepo = unit.GetFilterOptionRepo();
        }
        public IActionResult GetAll()
        {
            ViewBag.Filter = FilterRepo.GetAll().ToList();
            var AllFilter= FilterOptionRepo.GetAll();
            return View(AllFilter);
        }
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var item = FilterOptionRepo.GetById(Id);
            return View(item);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var data = FilterRepo.GetAll();
            ViewBag.FilterList = new SelectList(data.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FilterOptionVM filterVM)
        {
            if (ModelState.IsValid) {
                FilterOptionRepo.Add(filterVM.ToModel());
                await unit.Save();
                return RedirectToAction("GetAll");
            }

            var data = FilterRepo.GetAll();
            ViewBag.FilterList = new SelectList(data.ToList(), "Id", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var data = FilterRepo.GetAll();
            ViewBag.FilterList = new SelectList(data.ToList(), "Id", "Name");
            var filter = FilterOptionRepo.GetById(Id);
            return View(filter.ToVModel());

        }

        [HttpPost]
        public async Task<IActionResult> Edit(FilterOptionVM FOVM)
        {
            if (ModelState.IsValid)
            {
                FilterOptionRepo.Update(FOVM.ToModel());
                await unit.Save();
                return RedirectToAction("GetAll");
            }
            var data = FilterRepo.GetAll();
            ViewBag.FilterList = new SelectList(data.ToList(), "Id", "Name");
            return View(FOVM);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var e = FilterOptionRepo.GetById(Id);
            FilterOptionRepo.Remove(e);
            await unit.Save();
            return RedirectToAction("GetAll");
        }
    }
}
