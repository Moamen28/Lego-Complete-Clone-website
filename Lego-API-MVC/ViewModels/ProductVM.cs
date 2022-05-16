using Microsoft.AspNetCore.Http;
using Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Product Name")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [MaxLength(30, ErrorMessage = "Max Len 30")]
        public string ProdName { get; set; }

        [Required(ErrorMessage = "Enter Product Name")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [MaxLength(30, ErrorMessage = "Max Len 30")]
        public string ProdName_Ar { get; set; }
        [Required(ErrorMessage = "Enter Product Main Image")]
        public IFormFile MainImgURL { get; set; }


        [Required(ErrorMessage = "Enter Product Price")]
        public double ProdPrice { get; set; }
        [Required(ErrorMessage = "Enter Product Piece Count")]
        public int ProdPieceCount { get; set; }
        public byte ProdAge { get; set; }
        [Required(ErrorMessage = "Enter Product Stock")]
        public int ProdStock { get; set; }
        [Required(ErrorMessage = "Enter Product Description")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [MaxLength(2000, ErrorMessage = "Max Len 2000")]
        public string ProdDescreption { get; set; }

        [Required(ErrorMessage = "Enter Product Description")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [MaxLength(2000, ErrorMessage = "Max Len 2000")]
        public string ProdDescreption_Ar { get; set; }
        public int? CatId { get; set; }

        public string ProductImgName { get; set; }

        public List<IFormFile> ImgURL { get; set; }
    }

    public static class ProductVMExtention
    {

        public static Product ToModel(this ProductVM PVM)
        {
            return new Product
            {
                Id= PVM.Id,
                ProdName = PVM.ProdName,
                ProdPrice = PVM.ProdPrice,
                ProdPieceCount = PVM.ProdPieceCount,
                ProdAge = PVM.ProdAge,
                ProdStock = PVM.ProdStock,
                ProdDescreption = PVM.ProdDescreption,
                CatId = PVM.CatId,
                MainImg = "",
            };
        }

        public static ProductVM ToViewModel(this Product PVM)
        {
            return new ProductVM
            {
                Id = PVM.Id,
                ProdName = PVM.ProdName,
                ProdPrice = PVM.ProdPrice,
                ProdPieceCount = PVM.ProdPieceCount,
                ProdAge = PVM.ProdAge,
                ProdStock = PVM.ProdStock,
                ProdDescreption = PVM.ProdDescreption,
                CatId = PVM.CatId
            };
        }
    }
}
