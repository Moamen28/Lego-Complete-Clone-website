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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelRepository<Category> Catrepo;

        public CategoryController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            Catrepo = unitOfWork.GetCategryRepo();
        }
        #region Get All Category
        [HttpGet]
        [Route("AllCategory")]
        public async Task<IQueryable<Category>> GetAllCategory()
        {

            var result = Catrepo.GetAll();
            return result;
        }
        #endregion
    }
}
