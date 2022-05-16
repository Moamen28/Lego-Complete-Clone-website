using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Category:BaseModel
    {
        public string CatName { get; set; }
        public string CatName_Ar { get; set; }
        public int? SuppCatId { get; set; }

    }
    public partial class Category
    {
       //public virtual ICollection<Category> SuppCat { get; set; }
        public virtual Category SuppCat { get; set; }
        public virtual ICollection<FilterCategory> FilterCategories { get; set; }
        public virtual ICollection<Category> InverseSuppCat { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
