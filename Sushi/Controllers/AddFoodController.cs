using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Sushi.Data;
using Sushi.Data.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sushi.Controllers
{
    public class AddFoodController : Controller
    {

        private readonly appDBContent _appDBContent;

        public AddFoodController(appDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public IActionResult Index()
        {
            return View(_appDBContent.Food.ToList());
        }
        public IActionResult AddNewFood()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewFood(Food food)
        {
            _appDBContent.Food.Add(food);
            _appDBContent.SaveChanges();
            return RedirectToAction("AddNewFood");
        }
        [HttpPost]
        public IActionResult Delete(string name)
        {
            if (name != null)
            {
                Food food = _appDBContent.Food.FirstOrDefault(n => n.Name == name);
                if (food != null)
                {
                    _appDBContent.Food.Remove(food);
                   _appDBContent.SaveChanges();
                    
                }
            }
            return RedirectToAction("AddNewFood");
        }
        public ViewResult EditFood(string name)
        {
            if(name != null)
            {
                Food food = _appDBContent.Food.FirstOrDefault(n => n.Name == name);
                if (food != null)
                {
                    _appDBContent.Food.Remove(food);
                    _appDBContent.SaveChanges();

                }
            }
            return View();
        }
    }
}
