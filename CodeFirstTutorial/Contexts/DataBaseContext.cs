using Microsoft.EntityFrameworkCore;

namespace CodeFirstTutorial.Contexts;

public class DataBaseContext : DbContext
{
    public DbSet<Role>Roles { get; set; }
    public DbSet<Accounts> Accounts { get; set; }
    public DbSet<Products>Products { get; set; }
    public DbSet<Categories>Categories { get; set; }
    public DbSet<ProductsCategories>ProductsCategories { get; set; }
    public DbSet<ShoppingCarts>ShoppingCarts { get; set; }
    
    
    
    protected DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductsCategories>().HasKey(pc => new { pc.ProductId, pc.CategoryId });
        modelBuilder.Entity<ShoppingCarts>().HasKey(dc => new { dc.AccountId, dc.ProductId });
        
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, Name = "Admin" },
            new Role { RoleId = 2, Name = "User" }
        );

        modelBuilder.Entity<Accounts>().HasData(
            new Accounts
            {
                AccountId = 1,
                RoleId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123456789"
            },
            new Accounts
            {
                AccountId = 2,
                RoleId = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                Phone = "987654321"
            }
        );

        modelBuilder.Entity<Categories>().HasData(
            new Categories { CategoryId = 1, Name = "Electronics" },
            new Categories { CategoryId = 2, Name = "Books" }
        );

        modelBuilder.Entity<Products>().HasData(
            new Products
            {
                ProductId = 1,
                Name = "Laptop",
                Weight = 2.5m,
                Width = 35.5m,
                Height = 2.0m,
                Depth = 24.0m
            },
            new Products
            {
                ProductId = 2,
                Name = "Smartphone",
                Weight = 0.2m,
                Width = 7.0m,
                Height = 0.8m,
                Depth = 14.0m
            }
        );

        modelBuilder.Entity<ProductsCategories>().HasData(
            new ProductsCategories { ProductId = 1, CategoryId = 1 },
            new ProductsCategories { ProductId = 2, CategoryId = 1 }
        );

        modelBuilder.Entity<ShoppingCarts>().HasData(
            new ShoppingCarts { AccountId = 1, ProductId = 1, Amount = 1 },
            new ShoppingCarts { AccountId = 1, ProductId = 2, Amount = 2 },
            new ShoppingCarts { AccountId = 2, ProductId = 2, Amount = 1 }
        );
    }
}