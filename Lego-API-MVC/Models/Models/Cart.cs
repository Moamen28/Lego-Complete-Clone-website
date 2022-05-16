using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace Models.Models
{
   public  class Cart :BaseModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float price { get; set; }

        public ApplicationUser applicationUser { get; set; }
        public Product product { get; set; }
    }
}
