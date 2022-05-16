using System;
using System.Collections.Generic;
using USER_API.Authontaction;

#nullable disable

namespace Models.Models
{
    public partial class CustomerProductReview : BaseModel
    {
        public int ProdId { get; set; }
        public int ReviewId { get; set; }
        public int CustId { get; set; }

        public virtual ApplicationUser Applicationuser { get; set; }
        public virtual Product Prod { get; set; }
        public virtual Review Review { get; set; }
    }
}