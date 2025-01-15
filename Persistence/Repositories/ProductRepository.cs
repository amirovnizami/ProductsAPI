using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using ProductsAPI.Application.Interfaces;

namespace Persistence.Repositories;

public class ProductRepository:IProductRepository
{
    private readonly ProductAppDbContext _context;
    public ProductRepository(ProductAppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p=>p.ProductId == id);
        return product;
    }

    public async Task AddProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);  
        return _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await GetProductByIdAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public async  Task<bool> ProductExistsAsync(int id)
    {
        return await _context.Products.AnyAsync(p => p.ProductId == id);
    }
}