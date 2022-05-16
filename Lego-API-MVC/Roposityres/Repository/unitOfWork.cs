using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;

using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace Roposityres.Repository
{
    public class unitOfWork : IUnitOfWork
    {
        private IModelRepository<Category> repo;
        private IModelRepository<Product> prodRepo;
        private readonly IModelRepository<Order> orderRepo;
        private IModelRepository<ProductImage> prdImgRepo;
        IModelRepository<Filter> filterRepo;
        IModelRepository<FilterOption> filterOptionRepo;
        IModelRepository<FilterCategory> filterCatRepo;
        IRepositoryForMany<ProductOption> prodOptionRepo;
        IModelRepository<OrderItem> OrederItemRepo;
        IModelRepository<WishList> wishListRepo;
        IModelRepository<CustomerProductWishlist> custprodwishListRepo;
        private ApplicationDbContext context;


        public unitOfWork(IModelRepository<Category> _repo,
            ApplicationDbContext _Context,
            IModelRepository<FilterOption> _FilterOptionRepo,
            IModelRepository<Filter> _FilterRepo,
            IModelRepository<Product> _ProdRepo,
              IModelRepository<OrderItem> _OrederItemRepo,
            IModelRepository<Order> _OrderRepo, IRepositoryForMany<ProductOption> _ProdOptionRepo,
           IModelRepository<FilterCategory> _filterCatRepo, IModelRepository<ProductImage> _prdImgRepo,
           IModelRepository<WishList> _wishlistRepo, IModelRepository<CustomerProductWishlist> _custwishlistRepo)
        {
            repo = _repo;
            context = _Context;
            prodRepo = _ProdRepo;
            orderRepo = _OrderRepo;
            filterOptionRepo = _FilterOptionRepo;
            filterRepo = _FilterRepo;
            prodOptionRepo = _ProdOptionRepo;
            filterCatRepo = _filterCatRepo;
            prdImgRepo = _prdImgRepo;
            OrederItemRepo = _OrederItemRepo;
            wishListRepo = _wishlistRepo;
            custprodwishListRepo = _custwishlistRepo;
        }

        public async Task Save()
        {
             await context.SaveChangesAsync();
        }

        public IModelRepository<Category> GetCategryRepo()
        {
            return repo;
        }

        public IModelRepository<Product> GetProductRepo()
        {
            return prodRepo;
        }

        public IModelRepository<Order> GetOrderRepo()
        {
            return orderRepo;
        }

        public IModelRepository<Filter> GetFilterRepo()
        {
            return filterRepo;
        }
        public IModelRepository<FilterOption> GetFilterOptionRepo()
        {
            return filterOptionRepo;
        }
        public IRepositoryForMany<ProductOption> GetProdOptRepo()
        {
            return prodOptionRepo;
        }

        public IModelRepository<FilterCategory> GetFilterCategoryRepo()
        {
            return filterCatRepo;
        }

        public IModelRepository<ProductImage> GetPrdImgRepo()
        {
            return prdImgRepo;
        }

        public IModelRepository<OrderItem> OrderItemRepo()
        {
            return OrederItemRepo;
        }

        public IModelRepository<WishList> WishListRepo()
        {
            return wishListRepo;
        }

        public IModelRepository<CustomerProductWishlist> GetWishListRepo()
        {
            return custprodwishListRepo;
        }
    }
}