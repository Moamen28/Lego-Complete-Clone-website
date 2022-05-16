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
    public class FilterOptionConfiguration : IEntityTypeConfiguration<FilterOption>
    {
        public void Configure(EntityTypeBuilder<FilterOption> builder)
        {
            builder.ToTable("Filter_Option");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.FilterId).HasColumnName("Filter_ID");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Name_Ar)

              .HasMaxLength(50);
             
            builder.HasOne(d => d.Filter)
                .WithMany(p => p.FilterOptions)
                .HasForeignKey(d => d.FilterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Filter_Option_Filter");
        }
    }
}
