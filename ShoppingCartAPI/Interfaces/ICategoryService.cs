using ShoppingCartAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartAPI.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int Id);
        Task<Category> GetCategoryByName(string name);
        Task InsertCategory(Category category);
        Task updateCategory(Category category);
        Task DeleteCategory(int Id);
    }
}
