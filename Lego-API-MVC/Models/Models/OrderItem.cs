using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class OrderItem :BaseModel
    {

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float price { get; set; }
        public int Discount { get; set; }

        public Order order { get; set; }
        public Product product { get; set; }

    }
}
