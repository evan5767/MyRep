using Sushi.Data;
using Sushi.Data.Models;
using System;
using Sushi.Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Sushi.ViewModels;
using System.Collections.Generic;


namespace Sushi.Data.Repository
{
    public class OrdersRepository : IOrders
    {
        private readonly appDBContent _appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(appDBContent appDBContent, ShopCart shopCart)
        {
            this._appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public async Task<Order> GetOrder(string email) => await _appDBContent.Order.Include(o => o.OrderDetails).ThenInclude(od => od.Food).FirstOrDefaultAsync(o => o.Email == email);
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
                _appDBContent.ShopCartItems.RemoveRange(items);
            }
            _appDBContent.SaveChanges();
        }
        public async Task<IEnumerable<Order>> GetOrders() => await _appDBContent.Order.Include(o => o.OrderDetails).ThenInclude(od => od.Food).ToListAsync();

        public async Task DeleteOrder(int id)
        {
            var order = await _appDBContent.Order
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);

            _appDBContent.OrderDetail.RemoveRange(order.OrderDetails);
            _appDBContent.Order.Remove(order);

            await _appDBContent.SaveChangesAsync();
        }
        public void Save()
        {
            _appDBContent.SaveChanges();
        }
    }
}
