using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace Models.AuthClasses
{
    public class GetAllOrder
    {
        public DateTime Date { get; set; }
        public byte discount { get; set; }

        public int totalPrice { get; set; }

        public int CustId { get; set; }
        public int? TotalPrice { get; set; }

        public List<OrderItem> ordItem { get; set; }
    }
}
