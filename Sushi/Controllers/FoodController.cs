using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using System.Linq;
using Sushi.ViewModels;
using System.Runtime.ConstrainedExecution;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sushi.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFood _foodService;
        private readonly IAllCategory _catServiсe;

        public FoodController(IFood foodService, IAllCategory catServiсe)
        {
            _foodService = foodService;
            _catServiсe = catServiсe;
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
                food = _foodService.GetFood.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("rolls", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _foodService.GetFood.Where(i => i.Category.Name.Equals("Роллы")).OrderBy(i => i.Id);
                    currCategory = "Роллы";
                }
                else if (string.Equals("pizza", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _foodService.GetFood.Where(i => i.Category.Name.Contains("Пицца")).OrderBy(i => i.Id);
                    currCategory = "Пицца";
                }
                else if (string.Equals("salad", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _foodService.GetFood.Where(i => i.Category.Name.Contains("Салаты")).OrderBy(i => i.Id);
                    currCategory = "Салаты";
                }
                else if (string.Equals("WOK", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _foodService.GetFood.Where(i => i.Category.Name.Contains("WOK")).OrderBy(i => i.Id);
                    currCategory = "WOK";
                }
                else if (string.Equals("drink", category, StringComparison.OrdinalIgnoreCase))
                {
                    food = _foodService.GetFood.Where(i => i.Category.Name.Contains("Напитки")).OrderBy(i => i.Id);
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
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id != null)
            {
                _foodService.Delete(id);
                _foodService.Save();
            }
            return RedirectToAction("Index", "Offert");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateFoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var food = _foodService.ConvertToFood(model);
                _foodService.Create(food);
                _foodService.Save();

                return RedirectToAction("Index", "Offert");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var food = _foodService.GetObjectFood(id);
            var categories = _catServiсe.GetAllCategory();
            var model = _foodService.ConvertToEdit(food, categories);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditFoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var food = _foodService.GetObjectFood(model.Id);
            
                food.Name = model.Name;
                food.Description = model.Description;
                food.Price = model.Price;
                food.Category = model.Category;
                food.ToViewHome = model.ToViewHome;
                food.Img = model.Img;

                _foodService.Update(food);
                _foodService.Save();
                return RedirectToAction("Index", "Offert");
            }
            
            return View(model);
        }
        public ViewResult Contacts()
        {
            ViewBag.Message = "Контакты";
            return View();
        }
        
        public ViewResult AddFood()
        {
            ViewBag.Message = "Добавить товар на сайт";
            return View();
        }
    }
}

