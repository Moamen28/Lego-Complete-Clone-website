using Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class FilterVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Product Name")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [MaxLength(30, ErrorMessage = "Max Len 30")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Product Name")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [MaxLength(30, ErrorMessage = "Max Len 30")]
        public string Name_Ar { get; set; }
    }
    public static class FilterVMExtention
    {

        public static Filter ToModel(this FilterVM FVM)
        {
            return new Filter
            {
                Id = FVM.Id,
                Name = FVM.Name,
                Name_Ar = FVM.Name_Ar
            };
        }

        public static FilterVM ToViewModel(this Filter FVM)
        {
            return new FilterVM
            {
                Id = FVM.Id,
                Name = FVM.Name,
                Name_Ar = FVM.Name_Ar
            };
        }
    }
}
