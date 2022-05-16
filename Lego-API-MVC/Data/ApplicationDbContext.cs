using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models.Configrations;
using Models.Models;

namespace USER_API.Authontaction
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        public virtual DbSet<Category> Categories { get; set; }

        // public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerProduct> CustomerProducts { get; set; }

        public virtual DbSet<CustomerProductReview> CustomerProductReviews { get; set; }
        public virtual DbSet<CustomerProductWishlist> CustomerProductWishlists { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }
        public virtual DbSet<FilterCategory> FilterCategories { get; set; }

        //public virtual DbSet<FilterIncat> FilterIncats { get; set; }
        public virtual DbSet<FilterOption> FilterOptions { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }

        //public virtual DbSet<ProductIncat> ProductIncats { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Cart> carts { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=LegoDB;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            //builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new CustomerProductConfiguration());
            builder.ApplyConfiguration(new CustomerProductReviewConfiguration());
            builder.ApplyConfiguration(new FilterConfiguration());
            builder.ApplyConfiguration(new FilterCategoryConfiguration());
            builder.ApplyConfiguration(new FilterOptionConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
            builder.ApplyConfiguration(new ProductOptionConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new WishListConfiguration());
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new CustomerProductWishlistConfiguration());
            builder.ApplyConfiguration(new OrderItemEntityConfiguration());

            base.OnModelCreating(builder);
        }
    }
}