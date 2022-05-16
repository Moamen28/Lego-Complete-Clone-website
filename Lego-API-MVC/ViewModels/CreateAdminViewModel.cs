using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace ViewModels
{
    public class CreateAdminViewModel
    {
        [Required(ErrorMessage = "First Name Required")]
     //   [EmailAddress(ErrorMessage = "You Must Enter Valid First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
      //  [EmailAddress(ErrorMessage = "You Must Enter Valid Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address Required")]
       // [EmailAddress(ErrorMessage = "You Must Enter Valid Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Mail Required")]
        [EmailAddress(ErrorMessage = "You Must Enter Valid Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
    public static class CreateAdminViewModelExtintions
    {
        public static ApplicationUser ToModel(this CreateAdminViewModel adminVM)
        {
            return new ApplicationUser
            {
                FirstName=adminVM.FirstName,
                LastName = adminVM.LastName,
                Address = adminVM.Address,
                UserName = adminVM.Email,
                Email = adminVM.Email
            };
        }
    }
}
