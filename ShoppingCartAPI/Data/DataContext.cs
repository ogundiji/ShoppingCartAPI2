using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

    }
}