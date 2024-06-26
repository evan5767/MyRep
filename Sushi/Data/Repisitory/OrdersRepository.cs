using Sushi.Data;
using Sushi.Data.Models;
using System;
using Sushi.Data.Interfaces;


namespace Sushi.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly appDBContent _appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(appDBContent appDBContent, ShopCart shopCart)
        {
            this._appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDBContent.Order.Add(order);
            _appDBContent.SaveChanges();

            var items = shopCart.ListShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    FoodId = el.Food.Id,
                    OrderId = order.Id,
                    Price = (uint)el.Food.Price
                };
                _appDBContent.OrderDetail.Add(orderDetail);
            }
            _appDBContent.SaveChanges();
        }
    }
}
