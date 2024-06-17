using Microsoft.AspNetCore.Mvc;
using Sushi.Data.Models;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout() //IActionResult - потому что мы должны принимать данные из формы!!!
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order) 
        {
            shopCart.ListShopItems = shopCart.GetShopItems();

            if(shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "В корзине нет товаров!");
            }

            if(ModelState.IsValid) 
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан!";
            return View();
        }

    }
}
