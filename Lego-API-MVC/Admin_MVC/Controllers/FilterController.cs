using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class FilterController : Controller
    {
        private readonly IUnitOfWork unit;
        private readonly IModelRepository<Filter> filtRepo;
        private readonly IModelRepository<FilterOption> filtOPtRepo;
        private readonly IRepositoryForMany<ProductOption> ProdOptRepo;

        public FilterController(IUnitOfWork _Unit)
        {
            unit = _Unit;
            filtRepo = unit.GetFilterRepo();
            filtOPtRepo = unit.GetFilterOptionRepo();
            ProdOptRepo = unit.GetProdOptRepo();
        }

        public IActionResult GetAll()
        {
            var data = filtRepo.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var data = filtRepo.GetById(Id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return  View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(FilterVM f)
        {
            filtRepo.Add(f.ToModel());
            await unit.Save();
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public  IActionResult Edit(int Id)
        {
            var filter =  filtRepo.GetById(Id);
            return  View(filter.ToViewModel());
        }
        [HttpPost]
        public async Task< IActionResult > Edit(FilterVM f)
        {
             filtRepo .Update(f.ToModel());
             await unit .Save();
            return RedirectToAction("GetAll");
        }

        public async Task< IActionResult> Delete(int Id)
        {
            var filterOpt =  filtOPtRepo.GetAllOnly().Where(FO => FO.FilterId == Id);

            if (filterOpt != null)
            {
                    filtOPtRepo.DeleteRange(filterOpt);
            }
            var Entity =  filtRepo.GetById(Id);
              filtRepo.Remove(Entity);
             await unit.Save();
            return RedirectToAction("GetAll");
        }
    }
}
