using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class ProductImage : BaseModel
    {
        public int ProdId { get; set; }

        public string ProdImage { get; set; }

        public virtual Product Prod { get; set; }
    }
}
