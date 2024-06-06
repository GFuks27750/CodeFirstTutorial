using CodeFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstTutorial.Contexts;

public class DataBaseContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductsCategories { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.ProductId, pc.CategoryId });
        modelBuilder.Entity<ShoppingCart>().HasKey(dc => new { dc.AccountId, dc.ProductId });
        
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, Name = "User" }
        );

        modelBuilder.Entity<Account>().HasData(
            new Account
            {
                AccountId = 1,
                RoleId = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "j@k.com",
                Phone = "999888777"
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Ściąga" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                Name = "Ściągi na egzamin z APBD",
                Weight = 0.0m,
                Width = 0.0m,
                Height = 0.0m,
                Depth = 0.0m
            }
        );

        modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory { ProductId = 1, CategoryId = 1 }
        );

        modelBuilder.Entity<ShoppingCart>().HasData(
            new ShoppingCart { AccountId = 1, ProductId = 1, Amount = 1 }
        );
    }
}
