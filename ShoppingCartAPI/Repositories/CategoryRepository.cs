using ShoppingCartAPI.Data;
using ShoppingCartAPI.Interface;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Repository
{
    public class CategoryRepository : ICategoryService
    {
        private readonly DataContext _context;
        private readonly ICategoryService ICategory ;


        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
 
         async Task ICategoryService.DeleteCategory(int id)
        {
            var category = await ICategory.GetCategoryById(id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        async Task<IEnumerable<Category>> ICategoryService.GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        async Task<Category> ICategoryService.GetCategoryById(int id)
        {
             return await _context.Categories.FindAsync(id);
        }

        async Task<Category> ICategoryService.GetCategoryByName(string name)
        {
            return _context.Categories.Where(x => x.categoryName == name).FirstOrDefault();
        }

        async Task ICategoryService.InsertCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
         async Task ICategoryService.updateCategory(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
