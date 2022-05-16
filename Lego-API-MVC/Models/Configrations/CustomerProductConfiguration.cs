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
    public class CustomerProductConfiguration : IEntityTypeConfiguration<CustomerProduct>
    {
        public void Configure(EntityTypeBuilder<CustomerProduct> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Customer_Product");

            builder.Property(e => e.ProdId).HasColumnName("Prod_ID");

            builder.Property(e => e.CustId).HasColumnName("Cust_ID");

            builder.HasOne(d => d.Applicationuser)
                .WithMany(p => p.CustomerProducts)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Product_Customer");

            builder.HasOne(d => d.Prod)
                .WithMany(p => p.CustomerProducts)
                .HasForeignKey(d => d.ProdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Product_Product");
        }
    }
}