using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Review : BaseModel
    {
        //public Review()
        //{
        //    CustomerProductReviews = new HashSet<CustomerProductReview>();
        //}

        //public int Id { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
        public byte Recommend { get; set; }
        public byte BuildRate { get; set; }
        public byte ValueRate { get; set; }
        public byte PlayRate { get; set; }
        public byte OverallRate { get; set; }
        public virtual ICollection<CustomerProductReview> CustomerProductReviews { get; set; }
    }
}