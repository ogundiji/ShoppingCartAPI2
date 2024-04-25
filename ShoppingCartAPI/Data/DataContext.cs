using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Models;
using System.Reflection.Metadata;

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

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .Property(o => o.price)
            .HasColumnType("decimal(18,4)");
        }
    }
}