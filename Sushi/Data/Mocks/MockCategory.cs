using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using System.Collections.Generic;

namespace Sushi.Data.Mocks
{
    public class MockCategory : IAllCategory
    {
        public IEnumerable<Category> AllCategory
        {
            get
            {
                return new List<Category>
                {
                    new Category{Name = "Пицца", Description = "Классическая итальянская пицца"},
                    new Category{Name = "WOK", Description = "Восточная еда, приготовленная на сковороде WOK"},
                    new Category{Name = "Роллы", Description = "Японская кухня"},
                    new Category{Name = "Салаты", Description = "Освежающие салаты"},
                    new Category{Name = "Напитки", Description = "Холодные напитки, чай"}
                };
            }
        }
    }
}
