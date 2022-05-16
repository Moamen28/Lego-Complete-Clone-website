using Microsoft.AspNetCore.Identity;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace USER_API.Authontaction//Models.Models
{
    public class ApplicationUser : IdentityUser<int>//Considerd Customer & Admin Based on Roles
    {
        //[Required(ErrorMessage = "FisrtName Is Requierd")]
        #nullable enable
        public string? FirstName { get; set; }

        //[Required(ErrorMessage = "LastName Is Requierd")]
        public string? LastName { get; set; }

        //[Required(ErrorMessage = "Address Is Requierd")]
        public string? Address { get; set; }

        public virtual ICollection<CustomerProductReview>? CustomerProductReviews { get; set; }

        public virtual ICollection<CustomerProductWishlist>? CustomerProductWishlists { get; set; }

        public virtual ICollection<CustomerProduct>? CustomerProducts { get; set; }
        public virtual ICollection<Cart>? carts { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

    }
}