using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AuthClasses
{
    public class AddNewWishList
    {
        public string Name { get; set; }
        public int CustId { get; set; }
        public int ProdId { get; set; }

    }
}