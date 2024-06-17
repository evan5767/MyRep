using Microsoft.AspNetCore.Mvc;
using Sushi.Data;
using Sushi.Data.Models;

namespace Sushi.Controllers
{
    public class EditController : Controller
    {
        private readonly appDBContent _appDBContent;

        public EditController(appDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public IActionResult AddNewFood()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditFood(Food food)
        {
            _appDBContent.Food.Update(food);
            _appDBContent.SaveChanges();
            return RedirectToAction("AddNewFood");
        }
    }
}
