using Sushi.Data.Models;
using System.Collections.Generic;

namespace Sushi.Data.Interfaces
{
    public interface IAllFood
    {
        IEnumerable<Food> Food { get; }
        IEnumerable<Food> GetViewFoods {  get; }
        Food GetObjectFood(int foodId);
    }
}
