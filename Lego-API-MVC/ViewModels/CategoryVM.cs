using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CategoryVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string CatName_Ar { get; set; }
        public int? SubID { get; set; }
    }

    public static class  CategoryVMExtention{

        public static Category ToModel (this CategoryVM CVM)
        {
            return new Category
            {
                Id = CVM.id,
                CatName = CVM.Name,
                SuppCatId = CVM.SubID,
                CatName_Ar = CVM.CatName_Ar
            };
        }

        public static CategoryVM ToViewModel(this Category CVM)
        {
            return new CategoryVM
            {
                id = CVM.Id,
                Name = CVM.CatName,
                SubID = CVM.SuppCatId,
                CatName_Ar = CVM.CatName_Ar
            };
        }
    }
}
