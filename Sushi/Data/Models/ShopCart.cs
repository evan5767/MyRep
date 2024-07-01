using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        public string UserId { get; set; }
        public List<ShopCartItems> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
            var userManager = services.GetRequiredService<UserManager<User>>();
            var context = services.GetService<appDBContent>();
            ISession session = httpContextAccessor.HttpContext.Session;
            string userId = userManager.GetUserId(httpContextAccessor.HttpContext.User);
            if (string.IsNullOrEmpty(userId))
            {
                return null;
                //throw new InvalidOperationException("Авторизуйтесь на сайте, чтобы пользоваться корзиной!");
            }

            string userCartId = userId;
            session.SetString("UserCartId", userCartId);

            return new ShopCart(context)
            {
                ShopCartId = userCartId,
                UserId = userId
            };
        }

        public void AddToCart(Food food)
        {
            _appDBcontent.ShopCartItems.Add(new ShopCartItems
            {
                ShopCartTd = ShopCartId,
                Food = food,
                Price = food.Price,
                UserId = UserId
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
            return _appDBcontent.ShopCartItems.Where(c => c.UserId == UserId).Include(s => s.Food).ToList();
        }
    }
}
