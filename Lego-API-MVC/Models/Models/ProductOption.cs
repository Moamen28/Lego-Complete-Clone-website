using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class ProductOption : BaseModel
    {
        public int ProdId { get; set; }
        public int FilterOptionId { get; set; }

        public virtual FilterOption FilterOption { get; set; }
        public virtual Product Prod { get; set; }
    }
}
