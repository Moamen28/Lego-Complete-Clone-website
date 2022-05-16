using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configrations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {

            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.price).IsRequired();
            builder.Property(i => i.Quantity).IsRequired();

            builder.HasKey(c => new { c.ProductId, c.UserId });
            builder.HasOne(u => u.applicationUser).WithMany(u => u.carts).HasForeignKey(r => r.UserId);
            builder.HasOne(r => r.product).WithMany(p => p.carts).HasForeignKey(r => r.ProductId);
        }
    }

}
