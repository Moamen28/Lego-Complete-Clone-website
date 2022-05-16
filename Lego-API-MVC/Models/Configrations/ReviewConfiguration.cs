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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.Body)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(e => e.BuildRate).HasColumnName("Build_Rate");

            builder.Property(e => e.OverallRate).HasColumnName("Overall_Rate");

            builder.Property(e => e.PlayRate).HasColumnName("Play_Rate");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.ValueRate).HasColumnName("Value_Rate");
        }
    }
}
