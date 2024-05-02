using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Data
{
    public class DataContext : IdentityDbContext<User>
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

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });
            });

            modelBuilder.Entity< IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId });
            });



        }
    }
}