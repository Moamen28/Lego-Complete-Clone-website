using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class WishList : BaseModel
    {
        //public WishList()
        //{
        //    CustomerProductWishlists = new HashSet<CustomerProductWishlist>();
        //}

        //  public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CustomerProductWishlist> CustomerProductWishlists { get; set; }
    }
}