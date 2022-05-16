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
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
           
            builder.Property(oi => oi.price).IsRequired();
            builder.Property(oi => oi.Quantity).IsRequired();
            builder.HasKey(oi => oi.Id );
            builder.HasOne(oi => oi.order).WithMany(o => o.orderItems).HasForeignKey(oi => oi.OrderId);
            builder.HasOne(oi => oi.product).WithMany(p => p.orderItems).HasForeignKey(oi => oi.ProductId);
        }
    }
}
