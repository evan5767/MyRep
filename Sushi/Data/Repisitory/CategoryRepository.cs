using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sushi.Data.Interfaces;
using Sushi.Data.Models;
using System.Collections.Generic;
using System.Linq;

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

        //public Category GetCategory(int id)
        //{
        //    var cat = _appDBcontent.Category
        //        .FirstOrDefault(p => p.Id == id);

        //    return _mapper.Map<Category>(cat);
        //}
        public IEnumerable<Category> GetAllCategory()
        {
            var categories = _appDBcontent.Category.ToList();
            return categories;
        }
    }
}
