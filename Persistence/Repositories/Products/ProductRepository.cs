using Application.Interfaces.Repositories.Products;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationContext _context;

    public ProductRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAll()
    {
        var list = await _context.Products.ToListAsync();

        return list;

    }

    public async Task<Product> GetById(int id)
    {
        var category = await _context.Products.FindAsync(id);

        return category!;
    }

    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

    }

    public async Task Update(Product product, int id)
    {
        var entry = await _context.Products.FindAsync(id);
        _context.Entry(entry).CurrentValues.SetValues(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var eliminate = await _context.Products.FindAsync(id);
        _context.Products.Remove(eliminate);
        await _context.SaveChangesAsync();
    }
}