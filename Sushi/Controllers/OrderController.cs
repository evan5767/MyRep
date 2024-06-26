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

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        private readonly appDBContent _appDBContent;

        public OrderController(IAllOrders allOrders, ShopCart shopCart, appDBContent appDBContent)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
            _appDBContent = appDBContent;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopItems();

            if (shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "В корзине нет товаров!");
            }

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete", new { email = order.Email });
            }

            return View(order);
        }

        private string GenerateOrderEmailBody(IEnumerable<ViewOrderViewModel> orders)
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
            var order = await _appDBContent.Order
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Food)
                .FirstOrDefaultAsync(o => o.Email == email);

            var emailBody = GenerateOrderEmailBody(new List<ViewOrderViewModel>
            {
                new ViewOrderViewModel
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

            //от кого отправляем и заголовок

            message.From.Add(new MailboxAddress("Информация о заказе", "wania1999@yahoo.com"));

            //кому отправляем

            message.To.Add(new MailboxAddress(order.Name, order.Email));

            //тема письма

            message.Subject = "Спасибо за заказ!";

            //тело письма

            message.Body = new TextPart("plain")

            {

                Text = emailBody

            };

            using (var client = new SmtpClient())

            {

                //Указываем smtp сервер почты и порт

                client.Connect("smtp.mail.yahoo.com", 587, false);

                //Указываем свой Email адрес и пароль приложения

                client.Authenticate("wania1999@yahoo.com", "cdkbqnzkfeikjowd");

                client.Send(message);

                client.Disconnect(true);

            }
            ViewBag.Message = "Заказ успешно обработан!";
            return View();
        }
        
    }
}
