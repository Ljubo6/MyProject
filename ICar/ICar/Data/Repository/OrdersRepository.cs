using ICar.Data.Intrfaces;
using ICar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContext appDbContext;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDbContext appDbContext,ShopCart shopCart)
        {
            this.appDbContext = appDbContext;
            this.shopCart = shopCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDbContext.Order.Add(order);

            var items = shopCart.ListShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    CarId = el.Car.Id,  
                    Price = el.Car.Price,
                };
                appDbContext.OrderDetail.Add(orderDetail);

            }
            appDbContext.SaveChanges();
        }
    }
}
