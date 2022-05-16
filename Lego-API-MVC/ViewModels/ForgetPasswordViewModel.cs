using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Required Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
