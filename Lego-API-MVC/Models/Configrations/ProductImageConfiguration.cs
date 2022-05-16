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
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Product_Image");

            builder.Property(e => e.ProdId).HasColumnName("Prod_ID");

            builder.Property(e => e.ProdImage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Prod_Image");

            builder.HasOne(d => d.Prod)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Image_Product");
        }
    }
}
