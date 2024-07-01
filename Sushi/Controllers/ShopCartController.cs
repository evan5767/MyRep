using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sushi.Data;
using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using Sushi.Data.Repisitory;
using Sushi.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Sushi.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IFood _foodRepository;
        private readonly ShopCart _shopCart;
        public ShopCartController(IFood foodRep, ShopCart shopCart)
        {
            _foodRepository = foodRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }
        [HttpPost]
        public JsonResult addToCart(int id) 
        {
            var item = _foodRepository.GetObjectFood(id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            return Json(" ");
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
