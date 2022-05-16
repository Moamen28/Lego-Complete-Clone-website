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
    public class FilterCategoryConfiguration : IEntityTypeConfiguration<FilterCategory>
    {
        public void Configure(EntityTypeBuilder<FilterCategory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Filter_Category");

            builder.Property(e => e.CatId).HasColumnName("Cat_ID");

            builder.Property(e => e.FilterId).HasColumnName("Filter_ID");

            builder.HasOne(d => d.Cat)
                .WithMany(p => p.FilterCategories)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Filter_Category_Category");

            builder.HasOne(d => d.Filter)
                .WithMany(p => p.FilterCategories)
                .HasForeignKey(d => d.FilterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Filter_Category_Filter");
        }
    }
}
