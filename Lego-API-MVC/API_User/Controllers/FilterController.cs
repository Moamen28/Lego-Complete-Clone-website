using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class FilterController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelRepository<Category> categoryRepo;
        private readonly IModelRepository<Filter> filterRepo;
        private readonly IModelRepository<FilterCategory> filtercatRepo;
        public FilterController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            categoryRepo = unitOfWork.GetCategryRepo();
            filterRepo = unitOfWork.GetFilterRepo();
            filtercatRepo = unitOfWork.GetFilterCategoryRepo();
        }
        #region Get All Category
        [HttpGet]
        [Route("Category")]
        public async Task<IQueryable<Category>> GetAllCategory()
        {
            var allcat =  categoryRepo.GetAll();
            return allcat;
        }
        #endregion


       // Need To  Fixed
        #region Return all Filter in Specific Cateogray
        [HttpGet]
        [Route("FilterByCatID/{CatID}")]
        public async Task<IQueryable<Filter>> GetFilterByCatID(int CatID)
        {
            List<Filter> list = new List<Filter>();
            //IQueryable<Filter> res;
         //   var res;
            var q = filtercatRepo.GetAll().Where(f => f.CatId == CatID);
            foreach (var item in q)
            {
                list.Add (filterRepo.GetById(item.FilterId));
            }
            //   var result =  filtercatRepo.FindByCondition(i => i.CatId == CatID);
            return (IQueryable<Filter>)list;
        }
        #endregion
    }
}
