using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using Sushi.Data;
using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using Sushi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sushi.Data.Repisitory
{
    public class FoodRepository : IFood
    {
        private readonly appDBContent _appDBcontent;

        public FoodRepository(appDBContent appDBContent)
        {
            _appDBcontent = appDBContent;
        }

        public IEnumerable<Food> GetFood => _appDBcontent.Food.Include(c => c.Category);

        public IEnumerable<Food> GetViewFoods => _appDBcontent.Food.Where(p => p.ToViewHome).Include(c => c.Category);

        public Food GetObjectFood(int foodId) => _appDBcontent.Food.FirstOrDefault(p => p.Id == foodId);

        public Food ConvertToFood(CreateFoodViewModel model)
        {
            return new Food
            {
                Name = model.Name,
                Description = model.Description,
                Category = model.Category,
                Price = model.Price,
                Img = model.Img,
                ToViewHome = model.ToViewHome
            };
        }

        public EditFoodViewModel ConvertToEdit(Food model, IEnumerable<Category> categories)
        {
            return new EditFoodViewModel
            {
                Name = model.Name,
                Description = model.Description,
                Category = model.Category,
                Price = model.Price,
                Img = model.Img,
                ToViewHome = model.ToViewHome,
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Name,
                    Text = c.Name,
                    Selected = c.Name == model.Category.Name
                }).ToList()

            };
        }
        public void Create(Food food)
        { 
            _appDBcontent.Food.Add(food);
        }

        public void Update(Food food)
        {
            _appDBcontent.Update(food);
        }

        public void Delete(int id)
        {
            var food = _appDBcontent.Food.FirstOrDefault(p => p.Id == id);
            _appDBcontent.Remove(food);
        }

        public void AddToCart(int id)
        {
            var food = _appDBcontent.Food.FirstOrDefault(p => p.Id == id);
        }
        public void Save()
        {
            _appDBcontent.SaveChanges();
        }
    }
}
