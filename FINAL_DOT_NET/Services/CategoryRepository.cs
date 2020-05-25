using FINAL_DOT_NET.Data;
using FINAL_DOT_NET.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoriesContext _appDbContext;

        public CategoryRepository(CategoriesContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
    }
}
