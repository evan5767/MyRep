using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Runtime.InteropServices;

namespace Sushi.Data.Models
{
    public class ShopCart
    {
        private readonly appDBContent _appDBcontent;

        public ShopCart(appDBContent appDBContent)
        {
            this._appDBcontent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItems> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; 
            var context = services.GetService<appDBContent>(); 
            string ShopCartTd = session.GetString("CartId") ?? Guid.NewGuid().ToString();
                                                                                         

            session.SetString("CartId", ShopCartTd); 

            return new ShopCart(context)
            {
                ShopCartId = ShopCartTd
            };
        }

        public void AddToCart(Food food) 
        {
            _appDBcontent.ShopCartItems.Add(new ShopCartItems
            {
                ShopCartTd = ShopCartId,
                Food = food,
                Price = food.Price,
            });

            _appDBcontent.SaveChanges();
        }
        public void RemoveFromCart(int id)
        {
           var item = _appDBcontent.ShopCartItems.FirstOrDefault(x => x.Id == id);
           _appDBcontent.Remove(item);

            _appDBcontent.SaveChanges();
        }
       
        public List<ShopCartItems> GetShopItems() 
        {
            return _appDBcontent.ShopCartItems.Where(c => c.ShopCartTd == ShopCartId).Include(s => s.Food).ToList();
        }
    }
}
