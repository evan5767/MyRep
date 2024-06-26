using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            return RedirectToAction("Index", "Offert");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Food food = await _appDBContent.Food.FirstOrDefaultAsync(p => p.Id == id);
                if (food != null)
                {
                    _appDBContent.Food.Remove(food);
                    await _appDBContent.SaveChangesAsync();
                    return RedirectToAction("Index", "Offert");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Food food = await _appDBContent.Food.FirstOrDefaultAsync(p => p.Id == id);
                if (food != null) return View(food);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Food food)
        {
            _appDBContent.Food.Update(food);
            await _appDBContent.SaveChangesAsync();
            return RedirectToAction("Index", "Offert");
        }
    }
}
