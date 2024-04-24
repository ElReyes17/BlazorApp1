using Application.Interfaces.Repositories.Categories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<List<Category>> GetAll()
    {
        var list = await _context.Categories.ToListAsync();

        return list;

    }

    public async Task<Category> GetById(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        return category!;
    }

    public async Task Add(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

    }

    public async Task Update(Category category, int id)
    {
        var entry = await _context.Categories.FindAsync(id);
        _context.Entry(entry).CurrentValues.SetValues(category);
         await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
       var eliminate = await _context.Categories.FindAsync(id);
       _context.Categories.Remove(eliminate);
       await _context.SaveChangesAsync();


    }
}