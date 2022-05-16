using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class FilterOptionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FilterID { get; set; }
    }
    public static class FilterOptionVMEXtintion
    {
        public static FilterOption ToModel(this FilterOptionVM filteroptin)
        {
            return new FilterOption
            {
                Id = filteroptin.Id,
                Name = filteroptin.Name,
                FilterId = filteroptin.FilterID
            };
        }
        public static FilterOptionVM ToVModel(this FilterOption filteroptin)
        {
            return new FilterOptionVM
            {
                Id = filteroptin.Id,
                Name = filteroptin.Name,
                FilterID = filteroptin.FilterId
            };
        }
    }
}
