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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(e => e.Id).HasName("CatId");

            builder.ToTable("Category");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Cat_ID");

            builder.Property(e => e.CatName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cat_Name");

            builder.Property(e => e.CatName_Ar)
              .HasMaxLength(50)
              .IsUnicode(false)
              .HasColumnName("Cat_Name_Ar");

            builder.Property(e => e.SuppCatId).HasColumnName("SuppCatID");

            builder.HasOne(d => d.SuppCat)
                .WithMany(p => p.InverseSuppCat)
                .HasForeignKey(d => d.SuppCatId)
                .HasConstraintName("FK_Category_Category");
        }
    }
}
