using Microsoft.AspNetCore.Mvc;
using Sushi.Data.Models;
using Sushi.Data.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using Sushi.ViewModels;
using System.Collections.Generic;
using System.Text;
using MailKit.Search;
using Org.BouncyCastle.Asn1.X509;
using Sushi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using Sushi.Data.Repisitory;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrders _orderService;
        private readonly ShopCart _shopCart;

        public OrderController(IOrders allOrders, ShopCart shopCart)
        {
            this._orderService = allOrders;
            this._shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();
            if (_shopCart.ListShopItems == null)
            {
                ModelState.AddModelError("", "В корзине нет товаров!");
            }
            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(order);
                return RedirectToAction("Complete", new { email = order.Email });
            }
            return View(order);
        }

        public async Task<IActionResult> ShowOrder()
        {
            var orders = await _orderService.GetOrders();
            if (orders == null)
            {
                return NotFound();
            }
            var viewModel = orders.Select(o => new ShowOrderViewModel
            {
                Name = o.Name,
                Adress = o.Adress,
                OrderId = o.Id,
                OrderTime = o.OrderTime,
                OrderDetails = o.OrderDetails.Select(od => new OrderDetailViewModel
                {
                    FoodId = od.FoodId,
                    FoodName = od.Food.Name,
                    Price = od.Price
                }).ToList()
            }).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrder(id);

            return RedirectToAction("ShowOrder");
        }

        private string GenerateOrderEmailBody(IEnumerable<ShowOrderViewModel> orders)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Ваш заказ!");

            foreach (var order in orders)
            {
                stringBuilder.AppendLine($"Время: {order.OrderTime}");
                stringBuilder.AppendLine($"Клиент: {order.Name}");
                stringBuilder.AppendLine($"Адрес: {order.Adress}");
                stringBuilder.AppendLine(" ");
                stringBuilder.AppendLine("Детали: ");

                uint sumProd = 0;
                foreach (var item in order.OrderDetails)
                {
                    stringBuilder.AppendLine($"{item.FoodName} - {item.Price.ToString("c")}");
                    sumProd += item.Price;
                }

                stringBuilder.AppendLine(" ");
                stringBuilder.AppendLine($"Итого: {sumProd.ToString("c")}");
            }

            return stringBuilder.ToString();
        }

        public async Task<IActionResult> Complete(string email)
        {
            var order = await _orderService.GetOrder(email);
            var emailBody = GenerateOrderEmailBody(new List<ShowOrderViewModel>
            {
                new ShowOrderViewModel
                {
                    OrderId = order.OrderId,
                    OrderTime = order.OrderTime,
                    Name = order.Name,
                    Adress = order.Adress,
                    OrderDetails = order.OrderDetails.Select(d => new OrderDetailViewModel
                    {
                        FoodName = d.Food.Name,
                        Price = d.Price
                    }).ToList()
                }
            });


            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Информация о заказе", "wania1999@yahoo.com"));

            message.To.Add(new MailboxAddress(order.Name, order.Email));

            message.Subject = "Спасибо за заказ!";

            message.Body = new TextPart("plain")

            {

                Text = emailBody

            };

            using (var client = new SmtpClient())

            {

                client.Connect("smtp.mail.yahoo.com", 587, false);

                client.Authenticate("wania1999@yahoo.com", "cdkbqnzkfeikjowd");

                client.Send(message);

                client.Disconnect(true);

            }
            ViewBag.Message = "Заказ успешно обработан!";
            return View();
        }

    }
}
