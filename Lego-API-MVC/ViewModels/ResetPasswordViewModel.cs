using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ResetPasswordViewModel
    {
        //[Required(ErrorMessage = "UserName Reqired")]
        //[MinLength(4, ErrorMessage = "Min Length 4 ")]
        //public string UserName { get; set; }

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
        public string Token { get; set; }
    }
}
