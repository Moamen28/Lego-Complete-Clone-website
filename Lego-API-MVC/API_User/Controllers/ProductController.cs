using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Roposityres.Helper;
using Roposityres.interfaces;
using Roposityres.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelRepository<Product> productrepo;
        private readonly IModelRepository<ProductImage> productImgrepo;

        public ProductController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            productrepo = unitOfWork.GetProductRepo();
            productImgrepo = unitOfWork.GetPrdImgRepo();


        }
        #region Get All Product
        [HttpGet]
        [Route("Product")]
        public async Task<List<Product>> GetAllProduct()
        {

            var result = productrepo.GetAll().ToList();
            UploadHelper.GetAllByPathForProduct("Photos/", result);
            return result;
        }
        #endregion

        #region Get Product By ID
        [HttpGet]
        [Route("ProductByID/{PrdId}")]
        public async Task<Product> GetProductByID(int PrdId)
        {

            var result =  productrepo.GetById(PrdId);
            UploadHelper.GetOneByPath("Photos/", result); 
            return result;
        }

        #endregion

        #region Return all Product in Specific Cateogray
        [HttpGet]
        [Route("ProductByCatID/{CatID}")]
        public async Task<IQueryable<Product>> GetPrdByCatID(int CatID)
        {
            var result =  productrepo.FindByCondition(i => i.CatId == CatID);
            return result;
        }
        #endregion

        #region Search for Product By Name

        [HttpGet]
        [Route("Search/{search}")]
        public async Task<Product> Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var Search =  productrepo.FindByCondition(i => i.ProdName.Contains(search)
                || i.ProdDescreption.Contains(search));
                var result = Search.FirstOrDefault();
                if (Search.Any())
                {

                    return (Product)result;
                }
            }
            return (Product) productrepo.GetAll();
        }
        #endregion

        #region GetProductImage
        [HttpGet]
        [Route("ImgProduct/{PrdId}")]
        public async Task<List<ProductImage>> GetImgProductByID(int PrdId)
        {
            List<string> ImgProd = new List<string>();
            var result = productImgrepo.FindByCondition(i => i.ProdId == PrdId).ToList();
            UploadHelper.GetAllByPath("Photos/", result);

            return result;
        }
        #endregion

        #region Get All Image
        [HttpGet]
        [Route("ImgProduct")]
        public async Task<IQueryable<ProductImage>> GetAllImage()
        {

            var result = productImgrepo.GetAll();
            return result;
        }
        #endregion
    }
}