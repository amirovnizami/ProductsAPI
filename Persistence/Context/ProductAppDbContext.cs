using API.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ProductAppDbContext:IdentityDbContext<AppUser,AppRole,int>
{
    public ProductAppDbContext(DbContextOptions <ProductAppDbContext>options):base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Iphone 13", Price = 5000, IsActive = true },
            new Product { ProductId = 2, ProductName = "Iphone 14", Price = 6000, IsActive = true },
            new Product { ProductId = 3, ProductName = "Iphone 15", Price = 7000, IsActive = true },
            new Product { ProductId = 4, ProductName = "Iphone 16", Price = 8000, IsActive = true }
        );
    }
    public DbSet<Product> Products { get; set; }
}