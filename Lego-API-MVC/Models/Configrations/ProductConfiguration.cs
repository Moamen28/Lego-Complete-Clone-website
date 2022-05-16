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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Product");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Prod_ID");

            builder.Property(e => e.CatId).HasColumnName("Cat_ID");

            builder.Property(e => e.ProdAge).HasColumnName("Prod_Age");

            builder.Property(e => e.ProdDescreption)
                .HasMaxLength(3000)
                .HasColumnName("Prod_Descreption");

            builder.Property(e => e.ProdDescreption_Ar)
                .HasMaxLength(3000)
                .HasColumnName("Prod_Descreption_Ar");

            builder.Property(e => e.ProdName)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Prod_Name");

            builder.Property(e => e.ProdName_Ar)
                .HasMaxLength(80)
              
                .HasColumnName("Prod_Name_Ar");

            builder.Property(e => e.ProdPieceCount).HasColumnName("Prod_PieceCount");

            builder.Property(e => e.ProdPrice).HasColumnName("Prod_Price");

            builder.Property(e => e.ProdStock).HasColumnName("Prod_Stock");

            builder.HasOne(d => d.Cat)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK_Product_Category");
        }
    }
}
