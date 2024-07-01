
using Sushi.Data.Models;
using Sushi.ViewModels;
using System.Collections.Generic;

namespace Sushi.Data.Interfaces
{
    public interface IFood
    {
        IEnumerable<Food> GetFood { get; }
        IEnumerable<Food> GetViewFoods { get; }
        Food GetObjectFood(int foodId);

        public EditFoodViewModel ConvertToEdit(Food food, IEnumerable<Category> categories);
        public Food ConvertToFood(CreateFoodViewModel model);
        void Create(Food food);
        void Update(Food food);
        void Delete(int id);
        void AddToCart(int id);
        void Save();
    }
}
