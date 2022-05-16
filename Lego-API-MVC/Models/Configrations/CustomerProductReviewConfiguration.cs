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
    public class CustomerProductReviewConfiguration : IEntityTypeConfiguration<CustomerProductReview>
    {
        public void Configure(EntityTypeBuilder<CustomerProductReview> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Customer_Product_Review");

            builder.Property(e => e.ProdId).HasColumnName("Prod_ID");

            builder.Property(e => e.ReviewId).HasColumnName("Review_ID");

            builder.Property(e => e.CustId).HasColumnName("Cust_ID");

            builder.HasOne(d => d.Applicationuser)
                .WithMany(p => p.CustomerProductReviews)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Product_Review_Customer");

            builder.HasOne(d => d.Prod)
                .WithMany(p => p.CustomerProductReviews)
                .HasForeignKey(d => d.ProdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Product_Review_Product");

            builder.HasOne(d => d.Review)
                .WithMany(p => p.CustomerProductReviews)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Product_Review_Review");
        }
    }
}