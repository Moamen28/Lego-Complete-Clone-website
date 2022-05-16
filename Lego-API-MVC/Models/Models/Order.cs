using System;
using System.Collections.Generic;
using USER_API.Authontaction;

#nullable disable

namespace Models.Models
{
    public partial class Order : BaseModel
    {
        // public int Id { get; set; }
        public DateTime Date { get; set; }

        public byte Discount { get; set; }
        public int? TotalPrice { get; set; }
        public int CusId { get; set; }

        public virtual ApplicationUser Applicationuser { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
    }
}