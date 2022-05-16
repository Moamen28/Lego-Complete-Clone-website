using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Filter : BaseModel
    {
        //public Filter()
        //{
        //    FilterCategories = new HashSet<FilterCategory>();
        //    FilterOptions = new HashSet<FilterOption>();
        //}

        public string Name { get; set; }

        public string Name_Ar { get; set; }

        public virtual ICollection<FilterCategory> FilterCategories { get; set; }
        public virtual ICollection<FilterOption> FilterOptions { get; set; }
    }
}