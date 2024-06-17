using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using System.Collections.Generic;

namespace Sushi.Data.Repisitory
{
    public class CategoryRepository : IAllCategory
    {
        private readonly appDBContent _appDBcontent;

        public CategoryRepository(appDBContent appDBContent)
        {
            _appDBcontent = appDBContent;
        }
        public IEnumerable<Category> AllCategory => _appDBcontent.Category;

    }
}
