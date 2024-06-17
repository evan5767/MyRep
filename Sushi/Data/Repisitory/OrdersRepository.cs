using Sushi.Data;
using Sushi.Data.Models;
using System;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly appDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(appDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.ListShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    FoodId = el.Food.Id,
                    OrderId = order.Id,
                    Price = (uint)el.Food.Price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
