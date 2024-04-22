using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Data;
using ShoppingCartAPI.Interface;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Repository
{
    public class ProductRepository : IProductService
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        private readonly IProductService IProduct;
        async Task IProductService.DeleteProduct(int id)
        {
            var product = await IProduct.GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        async public Task<IEnumerable<Product>> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        async public Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        async public Task<Product> GetProductByName(string name)
        {
            return await _context.Products.FindAsync(name);
        }

        async public Task InsertProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        async public Task UpdateProduct(Product product)
        {
           _context.Products.Update(product);
            _context.SaveChanges();
        }
        async public Task<Product> GetProductByCode(string code)
        {
            return await _context.Products.FindAsync(code);
        }

        public Task<Product> GetIdByCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
