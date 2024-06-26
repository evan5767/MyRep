using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sushi.Data;
using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using Sushi.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Sushi.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllFood _foodRepository;
        private readonly ShopCart _shopCart;
        private readonly appDBContent _appDBcontent;
        public ShopCartController(IAllFood foodRep, ShopCart shopCart)
        {
            _foodRepository = foodRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()// данная функция будет позвоолять нам вызвать определенный html шаблон
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id) 
        {
           
            var item = _foodRepository.Food.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index"); 
        }
        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            if (id != null)
            {
                _shopCart.RemoveFromCart(id);
            }

            return RedirectToAction("Index");
        }
    }
}
