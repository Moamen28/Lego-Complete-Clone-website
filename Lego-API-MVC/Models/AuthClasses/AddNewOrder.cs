using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AuthClasses
{
    public class AddNewOrder
    {
        public DateTime Date { get; set; }
        public byte discount { get; set; }

        public int totalPrice { get; set; }

        public int CustId { get; set; }
        public int TotalPrice { get; set; }

        public List<NewOrderItem> ordItem { get; set;}

        //public int prodId { get; set; }
        //public int Quantity { get; set; }
        //public int price { get; set; }
        //public byte prodDiscount { get; set; }
    }
}
