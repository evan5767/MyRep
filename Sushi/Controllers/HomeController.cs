using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using System.Linq;
using Sushi.ViewModels;
using System.Runtime.ConstrainedExecution;
using Sushi.Data.Mocks;

namespace Sushi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllFood _allFood;
        private readonly IAllCategory _foodCategory;

        public HomeController(IAllFood allFood, IAllCategory allCaregory)
        {
            _allFood = allFood; 
            _foodCategory = allCaregory;
        }

        [Route("Home/List")]
        [Route("Home/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Food> food = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                food = _allFood.Food.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("rolls", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _allFood.Food.Where(i => i.Category.Name.Equals("Роллы")).OrderBy(i => i.Id);
                    currCategory = "Роллы";
                }
                else if (string.Equals("pizza", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _allFood.Food.Where(i => i.Category.Name.Contains("Пицца")).OrderBy(i => i.Id);
                    currCategory = "Пицца";
                }
                else if (string.Equals("salad", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _allFood.Food.Where(i => i.Category.Name.Contains("Салаты")).OrderBy(i => i.Id);
                    currCategory = "Салаты";
                }
                else if (string.Equals("WOK", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _allFood.Food.Where(i => i.Category.Name.Contains("WOK")).OrderBy(i => i.Id);
                    currCategory = "WOK";
                }
                else if (string.Equals("drink", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _allFood.Food.Where(i => i.Category.Name.Contains("Напитки")).OrderBy(i => i.Id);
                    currCategory = "Напитки";
                }

            }

            var foodObj = new FoodListViewModel
            {
                Foods = food,
                CurrCategory = currCategory
            };
            ViewBag.Title = "Страница с Food";

            return View(foodObj);
        }
        public ViewResult Contacts()
        {
            ViewBag.Message = "Контакты";
            return View();
        }

        public ViewResult AddFood()
        {
            ViewBag.Message = "Добавить товар на сайт";
            return View() ;
        }
    }
}
