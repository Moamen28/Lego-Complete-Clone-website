﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using USER_API.Authontaction;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220423225906_UpdateRole2")]
    partial class UpdateRole2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.Models.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Models.Models.ApplicationUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Models.Models.Cart", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("ProductId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("carts");
                });

            modelBuilder.Entity("Models.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Cat_ID")
                        .UseIdentityColumn();

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Cat_Name");

                    b.Property<int?>("SuppCatId")
                        .HasColumnType("int")
                        .HasColumnName("SuppCatID");

                    b.HasKey("Id")
                        .HasName("CatId");

                    b.HasIndex("SuppCatId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Models.Models.CustomerProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustId")
                        .HasColumnType("int")
                        .HasColumnName("Cust_ID");

                    b.Property<int>("ProdId")
                        .HasColumnType("int")
                        .HasColumnName("Prod_ID");

                    b.HasKey("Id");

                    b.HasIndex("CustId");

                    b.HasIndex("ProdId");

                    b.ToTable("Customer_Product");
                });

            modelBuilder.Entity("Models.Models.CustomerProductReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustId")
                        .HasColumnType("int")
                        .HasColumnName("Cust_ID");

                    b.Property<int>("ProdId")
                        .HasColumnType("int")
                        .HasColumnName("Prod_ID");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int")
                        .HasColumnName("Review_ID");

                    b.HasKey("Id");

                    b.HasIndex("CustId");

                    b.HasIndex("ProdId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Customer_Product_Review");
                });

            modelBuilder.Entity("Models.Models.CustomerProductWishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustId")
                        .HasColumnType("int")
                        .HasColumnName("Cust_ID");

                    b.Property<int>("ProdId")
                        .HasColumnType("int")
                        .HasColumnName("Prod_ID");

                    b.Property<int>("WishId")
                        .HasColumnType("int")
                        .HasColumnName("Wish_ID");

                    b.HasKey("Id");

                    b.HasIndex("CustId");

                    b.HasIndex("ProdId");

                    b.HasIndex("WishId");

                    b.ToTable("Customer_Product_Wishlist");
                });

            modelBuilder.Entity("Models.Models.Filter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Filter");
                });

            modelBuilder.Entity("Models.Models.FilterCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CatId")
                        .HasColumnType("int")
                        .HasColumnName("Cat_ID");

                    b.Property<int>("FilterId")
                        .HasColumnType("int")
                        .HasColumnName("Filter_ID");

                    b.HasKey("Id");

                    b.HasIndex("CatId");

                    b.HasIndex("FilterId");

                    b.ToTable("Filter_Category");
                });

            modelBuilder.Entity("Models.Models.FilterOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("FilterId")
                        .HasColumnType("int")
                        .HasColumnName("Filter_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FilterId");

                    b.ToTable("Filter_Option");
                });

            modelBuilder.Entity("Models.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("CusId")
                        .HasColumnType("int")
                        .HasColumnName("Cus_ID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<byte>("Discount")
                        .HasColumnType("tinyint");

                    b.Property<int?>("TotalPrice")
                        .HasColumnType("int")
                        .HasColumnName("Total_Price");

                    b.HasKey("Id");

                    b.HasIndex("CusId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Prod_ID")
                        .UseIdentityColumn();

                    b.Property<int?>("CatId")
                        .HasColumnType("int")
                        .HasColumnName("Cat_ID");

                    b.Property<byte>("ProdAge")
                        .HasColumnType("tinyint")
                        .HasColumnName("Prod_Age");

                    b.Property<string>("ProdDescreption")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)")
                        .HasColumnName("Prod_Descreption");

                    b.Property<string>("ProdName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("Prod_Name");

                    b.Property<int>("ProdPieceCount")
                        .HasColumnType("int")
                        .HasColumnName("Prod_PieceCount");

                    b.Property<double>("ProdPrice")
                        .HasColumnType("float")
                        .HasColumnName("Prod_Price");

                    b.Property<int>("ProdStock")
                        .HasColumnType("int")
                        .HasColumnName("Prod_Stock");

                    b.HasKey("Id");

                    b.HasIndex("CatId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Models.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProdId")
                        .HasColumnType("int")
                        .HasColumnName("Prod_ID");

                    b.Property<string>("ProdImage")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Prod_Image");

                    b.HasKey("Id");

                    b.HasIndex("ProdId");

                    b.ToTable("Product_Image");
                });

            modelBuilder.Entity("Models.Models.ProductOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FilterOptionId")
                        .HasColumnType("int")
                        .HasColumnName("Filter_Option_ID");

                    b.Property<int>("ProdId")
                        .HasColumnType("int")
                        .HasColumnName("Prod_ID");

                    b.HasKey("Id")
                        .HasName("PK_Filter_Product");

                    b.HasIndex("FilterOptionId");

                    b.HasIndex("ProdId");

                    b.ToTable("Product_Option");
                });

            modelBuilder.Entity("Models.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte>("BuildRate")
                        .HasColumnType("tinyint")
                        .HasColumnName("Build_Rate");

                    b.Property<byte>("OverallRate")
                        .HasColumnType("tinyint")
                        .HasColumnName("Overall_Rate");

                    b.Property<byte>("PlayRate")
                        .HasColumnType("tinyint")
                        .HasColumnName("Play_Rate");

                    b.Property<byte>("Recommend")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<byte>("ValueRate")
                        .HasColumnType("tinyint")
                        .HasColumnName("Value_Rate");

                    b.HasKey("Id");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Models.Models.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("USER_API.Authontaction.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Models.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("USER_API.Authontaction.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("USER_API.Authontaction.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("USER_API.Authontaction.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Models.ApplicationUserRole", b =>
                {
                    b.HasOne("Models.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USER_API.Authontaction.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Models.Cart", b =>
                {
                    b.HasOne("Models.Models.Product", "product")
                        .WithMany("carts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USER_API.Authontaction.ApplicationUser", "applicationUser")
                        .WithMany("carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("applicationUser");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Models.Models.Category", b =>
                {
                    b.HasOne("Models.Models.Category", "SuppCat")
                        .WithMany("InverseSuppCat")
                        .HasForeignKey("SuppCatId")
                        .HasConstraintName("FK_Category_Category");

                    b.Navigation("SuppCat");
                });

            modelBuilder.Entity("Models.Models.CustomerProduct", b =>
                {
                    b.HasOne("USER_API.Authontaction.ApplicationUser", "Applicationuser")
                        .WithMany("CustomerProducts")
                        .HasForeignKey("CustId")
                        .HasConstraintName("FK_Customer_Product_Customer")
                        .IsRequired();

                    b.HasOne("Models.Models.Product", "Prod")
                        .WithMany("CustomerProducts")
                        .HasForeignKey("ProdId")
                        .HasConstraintName("FK_Customer_Product_Product")
                        .IsRequired();

                    b.Navigation("Applicationuser");

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("Models.Models.CustomerProductReview", b =>
                {
                    b.HasOne("USER_API.Authontaction.ApplicationUser", "Applicationuser")
                        .WithMany("CustomerProductReviews")
                        .HasForeignKey("CustId")
                        .HasConstraintName("FK_Customer_Product_Review_Customer")
                        .IsRequired();

                    b.HasOne("Models.Models.Product", "Prod")
                        .WithMany("CustomerProductReviews")
                        .HasForeignKey("ProdId")
                        .HasConstraintName("FK_Customer_Product_Review_Product")
                        .IsRequired();

                    b.HasOne("Models.Models.Review", "Review")
                        .WithMany("CustomerProductReviews")
                        .HasForeignKey("ReviewId")
                        .HasConstraintName("FK_Customer_Product_Review_Review")
                        .IsRequired();

                    b.Navigation("Applicationuser");

                    b.Navigation("Prod");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Models.Models.CustomerProductWishlist", b =>
                {
                    b.HasOne("USER_API.Authontaction.ApplicationUser", "Applicationuser")
                        .WithMany("CustomerProductWishlists")
                        .HasForeignKey("CustId")
                        .HasConstraintName("FK_Customer_Product_Wishlist_Customer")
                        .IsRequired();

                    b.HasOne("Models.Models.Product", "Prod")
                        .WithMany("CustomerProductWishlists")
                        .HasForeignKey("ProdId")
                        .HasConstraintName("FK_Customer_Product_Wishlist_Product")
                        .IsRequired();

                    b.HasOne("Models.Models.WishList", "Wish")
                        .WithMany("CustomerProductWishlists")
                        .HasForeignKey("WishId")
                        .HasConstraintName("FK_Customer_Product_Wishlist_WishList")
                        .IsRequired();

                    b.Navigation("Applicationuser");

                    b.Navigation("Prod");

                    b.Navigation("Wish");
                });

            modelBuilder.Entity("Models.Models.FilterCategory", b =>
                {
                    b.HasOne("Models.Models.Category", "Cat")
                        .WithMany("FilterCategories")
                        .HasForeignKey("CatId")
                        .HasConstraintName("FK_Filter_Category_Category")
                        .IsRequired();

                    b.HasOne("Models.Models.Filter", "Filter")
                        .WithMany("FilterCategories")
                        .HasForeignKey("FilterId")
                        .HasConstraintName("FK_Filter_Category_Filter")
                        .IsRequired();

                    b.Navigation("Cat");

                    b.Navigation("Filter");
                });

            modelBuilder.Entity("Models.Models.FilterOption", b =>
                {
                    b.HasOne("Models.Models.Filter", "Filter")
                        .WithMany("FilterOptions")
                        .HasForeignKey("FilterId")
                        .HasConstraintName("FK_Filter_Option_Filter")
                        .IsRequired();

                    b.Navigation("Filter");
                });

            modelBuilder.Entity("Models.Models.Order", b =>
                {
                    b.HasOne("USER_API.Authontaction.ApplicationUser", "Applicationuser")
                        .WithMany("Orders")
                        .HasForeignKey("CusId")
                        .HasConstraintName("FK_Order_Customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicationuser");
                });

            modelBuilder.Entity("Models.Models.Product", b =>
                {
                    b.HasOne("Models.Models.Category", "Cat")
                        .WithMany("Products")
                        .HasForeignKey("CatId")
                        .HasConstraintName("FK_Product_Category");

                    b.Navigation("Cat");
                });

            modelBuilder.Entity("Models.Models.ProductImage", b =>
                {
                    b.HasOne("Models.Models.Product", "Prod")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProdId")
                        .HasConstraintName("FK_Product_Image_Product")
                        .IsRequired();

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("Models.Models.ProductOption", b =>
                {
                    b.HasOne("Models.Models.FilterOption", "FilterOption")
                        .WithMany("ProductOptions")
                        .HasForeignKey("FilterOptionId")
                        .HasConstraintName("FK_Product_Option_Filter_Option")
                        .IsRequired();

                    b.HasOne("Models.Models.Product", "Prod")
                        .WithMany("ProductOptions")
                        .HasForeignKey("ProdId")
                        .HasConstraintName("FK_Product_Option_Product")
                        .IsRequired();

                    b.Navigation("FilterOption");

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("Models.Models.Category", b =>
                {
                    b.Navigation("FilterCategories");

                    b.Navigation("InverseSuppCat");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Models.Models.Filter", b =>
                {
                    b.Navigation("FilterCategories");

                    b.Navigation("FilterOptions");
                });

            modelBuilder.Entity("Models.Models.FilterOption", b =>
                {
                    b.Navigation("ProductOptions");
                });

            modelBuilder.Entity("Models.Models.Product", b =>
                {
                    b.Navigation("carts");

                    b.Navigation("CustomerProductReviews");

                    b.Navigation("CustomerProducts");

                    b.Navigation("CustomerProductWishlists");

                    b.Navigation("ProductImages");

                    b.Navigation("ProductOptions");
                });

            modelBuilder.Entity("Models.Models.Review", b =>
                {
                    b.Navigation("CustomerProductReviews");
                });

            modelBuilder.Entity("Models.Models.WishList", b =>
                {
                    b.Navigation("CustomerProductWishlists");
                });

            modelBuilder.Entity("USER_API.Authontaction.ApplicationUser", b =>
                {
                    b.Navigation("carts");

                    b.Navigation("CustomerProductReviews");

                    b.Navigation("CustomerProducts");

                    b.Navigation("CustomerProductWishlists");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
