
using Sushi.Data.Models;
using System.Collections.Generic;

namespace Sushi.Data.Interfaces
{
    public interface IAllCategory
    {
        IEnumerable<Category> AllCategory { get; }

        //Category GetCategory(int id);
        IEnumerable< Category> GetAllCategory();
    }
}
