using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int Id);
        Task<Product> GetProductByName(string name);
        Task<Product> GetIdByCode(string code);
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int Id);
    }
}
