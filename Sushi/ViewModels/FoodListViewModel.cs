
using Sushi.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace Sushi.ViewModels
{
    public class FoodListViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public string CurrCategory { get; set; }
    }
}
