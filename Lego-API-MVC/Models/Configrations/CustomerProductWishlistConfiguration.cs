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
    public class CustomerProductWishlistConfiguration : IEntityTypeConfiguration<CustomerProductWishlist>
    {
        public void Configure(EntityTypeBuilder<CustomerProductWishlist> builder)
        {
            builder.HasKey(e =>e.Id);

            builder.ToTable("Customer_Product_Wishlist");

            builder.Property(e => e.WishId).HasColumnName("Wish_ID");

            builder.Property(e => e.CustId).HasColumnName("Cust_ID");

            builder.Property(e => e.ProdId).HasColumnName("Prod_ID");

            builder.HasOne(d => d.Applicationuser)
                .WithMany(p => p.CustomerProductWishlists)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Product_Wishlist_Customer");

            builder.HasOne(d => d.Prod)
                .WithMany(p => p.CustomerProductWishlists)
                .HasForeignKey(d => d.ProdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Product_Wishlist_Product");

            builder.HasOne(d => d.Wish)
                .WithMany(p => p.CustomerProductWishlists)
                .HasForeignKey(d => d.WishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Product_Wishlist_WishList");
        }
    }
}