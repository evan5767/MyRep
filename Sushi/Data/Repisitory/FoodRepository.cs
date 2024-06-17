using Microsoft.EntityFrameworkCore;
using Sushi.Data;
using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sushi.Data.Repisitory
{
    public class FoodRepository : IAllFood
    {
        private readonly appDBContent _appDBcontent;

        public FoodRepository(appDBContent appDBContent)
        {
            _appDBcontent = appDBContent;
        }

        public IEnumerable<Food> Food => _appDBcontent.Food.Include(c => c.Category);

        public IEnumerable<Food> GetViewFoods => _appDBcontent.Food.Where(p => p.ToViewHome).Include(c => c.Category);

        public Food GetObjectFood(int foodId) => _appDBcontent.Food.FirstOrDefault(p => p.Id == foodId);

    }
}
