using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sushi.Data;
using Sushi.Data.Models;
using Sushi.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Sushi.Controllers
{
    public class ViewOrderController : Controller
    {
        private readonly appDBContent _appDBcontent;

        public ViewOrderController(appDBContent context)
        {
            _appDBcontent = context;
        }

        public async Task<IActionResult> OrderDetails(int Id)
        {
            var orders = await _appDBcontent.Order
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Food)
            .ToListAsync();

            if (orders == null)
            {
                return NotFound();
            }

            var viewModel = orders.Select(o => new ViewOrderViewModel
            {
                Name = o.Name,
                Adress  = o.Adress,
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
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _appDBcontent.Order
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            // Удаление деталей заказа
            _appDBcontent.OrderDetail.RemoveRange(order.OrderDetails);

            // Удаление заказа
            _appDBcontent.Order.Remove(order);

            await _appDBcontent.SaveChangesAsync();
            return RedirectToAction("OrderDetails");
        }
    }
}
