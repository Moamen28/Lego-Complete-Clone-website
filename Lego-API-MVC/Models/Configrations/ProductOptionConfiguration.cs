using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configrations
{
    public class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK_Filter_Product");

            builder.ToTable("Product_Option");

            builder.Property(e => e.ProdId).HasColumnName("Prod_ID");

            builder.Property(e => e.FilterOptionId).HasColumnName("Filter_Option_ID");

            builder.HasOne(d => d.FilterOption)
                .WithMany(p => p.ProductOptions)
                .HasForeignKey(d => d.FilterOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Option_Filter_Option");

            builder.HasOne(d => d.Prod)
                .WithMany(p => p.ProductOptions)
                .HasForeignKey(d => d.ProdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Option_Product");
        }
    }
}
