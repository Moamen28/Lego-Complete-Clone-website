using System;
using System.Collections.Generic;
#nullable disable


namespace Models.Models
{
    public partial class Product :BaseModel
    {
        public string MainImg { get; set; }
        public string ProdName { get; set; }
        public string ProdName_Ar { get; set; }
        public double ProdPrice { get; set; }
        public int ProdPieceCount { get; set; }
        public byte ProdAge { get; set; }
        public int ProdStock { get; set; }
        public string ProdDescreption { get; set; }
        public string ProdDescreption_Ar { get; set; }
        public int? CatId { get; set; }
    }
    public partial class Product
    {
        public virtual Category Cat { get; set; }
        public virtual ICollection<CustomerProductReview> CustomerProductReviews { get; set; }
        public virtual ICollection<CustomerProductWishlist> CustomerProductWishlists { get; set; }
        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
        public virtual ICollection<Cart> carts { get; set; }
    }
}
