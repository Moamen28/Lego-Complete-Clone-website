using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.AuthClasses;
using Models.Models;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrdersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelRepository<Order> OrderRepo;
        private readonly IModelRepository<Product> ProdRepo;
        private readonly IModelRepository<OrderItem> OrderItemRepo;
        private readonly IModelRepository<WishList> wishListRepo;
        private readonly IModelRepository<CustomerProductWishlist> custProWishListRepo;
        public UserOrdersController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            OrderRepo = unitOfWork.GetOrderRepo();
            OrderItemRepo = unitOfWork.OrderItemRepo();
            wishListRepo = unitOfWork.WishListRepo();
            custProWishListRepo = unitOfWork.GetWishListRepo();
            ProdRepo = unitOfWork.GetProductRepo();
        }

        #region Add Order To DataBase
        [HttpPost]
        [Route("Order/add")]
        public async Task<Order> AddOrder(Order order)
        {
            var result = OrderRepo.Add(order);
            await unitOfWork.Save();
            return result;
        }
        #endregion
        //   [Authorize(Roles = UserRoles.Admin)]
        #region Delete Order
        [HttpDelete]
        [Route("Order/delete")]
        public async Task<Order> DeleteOrder(Order order)
        {
            var result = OrderRepo.Remove(order);
            await unitOfWork.Save();
            return result;
        }

        #endregion

        #region Get Order By User ID
        [HttpGet]
        [Route("OrderByUserId/{userId}")]
        public async Task<IQueryable<Order>> GetOrder(int userId)
        {
            var result = OrderRepo.FindByCondition(i => i.CusId == userId);

            return result;
        }
        #endregion

        #region Get Oreder Item

        [HttpGet]
        [Route("Order/Items/{orderId}")]
        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            var Result = OrderItemRepo.FindByCondition(i => i.OrderId == orderId);
            return Result.ToList();
        }
        #endregion

        #region Add OrderItem To DataBase
        [HttpPost]
        [Route("OrderItem/add")]
        public async Task<OrderItem> AddOrderItem(OrderItem orderitem)
        {
            var result = OrderItemRepo.Add(orderitem);
            await unitOfWork.Save();
            return result;
        }
        #endregion



        [HttpPost]
        [Route("AddNewOrder")]
        public async Task<AddNewOrder> AddNewOrderAndOrderItem(AddNewOrder ord)
        {
            var order = new Order()
            {
                CusId = ord.CustId,
                Discount = ord.discount,
                Date = ord.Date,
                TotalPrice = ord.totalPrice
            };
            OrderRepo.Add(order);
            await unitOfWork.Save();
            foreach(var o in ord.ordItem)
            {
                var OrderItem = new OrderItem()
                {
                    OrderId = order.Id,
                    price = o.price,
                    Quantity = o.Quantity,
                    ProductId = o.prodId,
                    Discount = o.prodDiscount
                };
                OrderItemRepo.Add(OrderItem);
                await unitOfWork.Save();
                var prod = ProdRepo.GetById(OrderItem.Id);
                prod.ProdStock -= OrderItem.Quantity;
                await unitOfWork.Save();
            }
            return ord;
        }

        #region Add WishList To DataBase
        [HttpPost]
        [Route("WishList/add")]


        public async Task<AddNewWishList> AddNewWishListItem(AddNewWishList addNew)
        {
            var wish = new WishList()
            {
                Name = addNew.Name
            };
            wishListRepo.Add(wish);
            await unitOfWork.Save();

            var wishItem = new CustomerProductWishlist()
            {
                WishId = wish.Id,
                CustId = addNew.CustId,
                ProdId = addNew.ProdId
            };
            custProWishListRepo.Add(wishItem);
            await unitOfWork.Save();


            return addNew;
        }

        //public async Task<WishList> AddWishList(WishList wishList)
        //{
        //    var result = wishListRepo.Add(wishList);
        //    await unitOfWork.Save();
        //    return result;
        //}
        #endregion

        #region Get WishList By User ID
        [HttpGet]
        [Route("WishListByUserId/{userId}")]
        public async Task<IQueryable<CustomerProductWishlist>> GetWishList(int userId)
        {
            var result = custProWishListRepo.FindByCondition(i => i.CustId == userId);

            return result;
        }
        #endregion

        [HttpGet]
        [Route("AddNewOrder")]
        public async Task<GetAllOrder> GetOrderAndOrderItem(int ID)
        {
            var result  = OrderRepo.GetById(ID);
            var res = await GetOrderItems(result.Id);
            var arry = new GetAllOrder()
            {
                CustId = result.CusId,
                discount = result.Discount,
                Date = result.Date,
                TotalPrice = result.TotalPrice,
                ordItem = res
            };

            return arry;
        }

    }
}