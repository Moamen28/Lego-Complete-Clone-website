using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Roposityres.Helper;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using USER_API.Authontaction;
using ViewModels;

namespace Admin_MVC.Models.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unit;
        private readonly IModelRepository<Product> ProdRepo;
        private readonly IModelRepository<Category> CatRepo;
        private readonly IModelRepository<ProductImage> prodImgRepo;

        public ProductController(IUnitOfWork _Unit)
        {
            unit = _Unit;
            ProdRepo = unit.GetProductRepo();
            CatRepo = unit.GetCategryRepo();
            prodImgRepo = unit.GetPrdImgRepo();
        }

        public IActionResult Create()
        {
            var data =  CatRepo.GetAll();
            ViewBag.CategoryList = new SelectList(data.ToList(), "Id", "CatName");
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(ProductVM c)
        {
            if (ModelState.IsValid)
            {
                var model = c.ToModel();
                model.MainImg = UploadHelper.SaveOneFile(c.MainImgURL, "Photos");
                ProdRepo.Add(model);
                await unit.Save();
                List<string> ImgProdToDB = new List<string>();
                ImgProdToDB = UploadHelper.SaveFile(c.ImgURL, "Photos");
                foreach (var i in ImgProdToDB)
                {
                    var ProdImg = new ProductImage()
                    {
                        ProdId = model.Id,
                        ProdImage =i
                    };
                    prodImgRepo.Add(ProdImg);
                    await unit.Save();
                }
                return RedirectToAction("GetAll");
            }
            var data =  CatRepo.GetAll();
            ViewBag.CategoryList = new SelectList(data.ToList(), "Id", "CatName");
                return View();
    }



        public IActionResult GetAll()
        {
            ViewBag.Category = CatRepo.GetAll().ToList();
            var data = ProdRepo.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            ViewBag.Img = prodImgRepo.GetAll().Where(p => p.ProdId == Id).ToList();
            ViewBag.Category = CatRepo.GetAll().ToList();
            var data = ProdRepo.GetById(Id);
            return View(data);
        }



        public  IActionResult Edit(int Id)
        {
            var Pro =  ProdRepo.GetById(Id);
            var data =  CatRepo.GetAll();
            ViewBag.CategoryList = new SelectList(data.ToList(), "Id", "CatName");
            return View(Pro.ToViewModel());
        }
        [HttpPost]
        public  async Task<IActionResult> Edit(ProductVM p)
        {
                if (ModelState.IsValid)
                {
                var model = p.ToModel();
                UploadHelper.RemoveFile("Photos/", model.MainImg);
                model.MainImg = UploadHelper.SaveOneFile(p.MainImgURL, "Photos");
                ProdRepo.Update(model);

                    var ImgName = new List<string>();
                    var ImgProd = prodImgRepo.GetAll().Where(Img => Img.ProdId == p.Id);
                    foreach (var itm in ImgProd)
                    {
                        ImgName.Add(itm.ProdImage);
                    }
                    UploadHelper.RemoveListOfFile("Photos/", ImgName);
                    prodImgRepo.DeleteRange(ImgProd);

                    await unit.Save();


                    List<string> ImgProdToDB = new List<string>();
                    ImgProdToDB = UploadHelper.SaveFile(p.ImgURL, "Photos");
                    foreach (var i in ImgProdToDB)
                    {
                        var ProdImg = new ProductImage()
                        {
                            ProdId = p.ToModel().Id,
                            ProdImage = i
                        };
                        prodImgRepo.Add(ProdImg);
                        await unit.Save();
                    }


                return RedirectToAction("GetAll");
                }
            var data =  CatRepo.GetAll();
            ViewBag.CategoryList = new SelectList(data.ToList(), "Id", "CatName");
            return View(p);
        }

        [HttpPost]
        public  async Task<IActionResult> Delete(int Id)
        {
            var ImgName = new List<string>();
            var entet =  ProdRepo.GetById(Id);
            var ImgProd = prodImgRepo.GetAll().Where(Img => Img.ProdId == Id);
            foreach (var itm in ImgProd)
            {
                ImgName.Add(itm.ProdImage);
            }
            UploadHelper.RemoveFile("Photos/", entet.MainImg);
            UploadHelper.RemoveListOfFile("Photos/", ImgName);
            prodImgRepo.DeleteRange(ImgProd);
            ProdRepo.Remove(entet);
            await  unit.Save();
            return RedirectToAction("GetAll");

        }


    }
}
