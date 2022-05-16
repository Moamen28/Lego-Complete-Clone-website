using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class FilterOption : BaseModel
    {
        //public FilterOption()
        //{
        //    ProductOptions = new HashSet<ProductOption>();
        //}

        //       public int Id { get; set; }
        public string Name { get; set; }
        public string Name_Ar { get; set; }
        public int FilterId { get; set; }

        public virtual Filter Filter { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}