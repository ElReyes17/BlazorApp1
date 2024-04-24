using Domain.Entities;

namespace Application.Interfaces.Repositories.Categories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAll();

    Task<Category> GetById(int id);

    Task Add(Category category);

    Task Update(Category category, int id);

    Task Delete(int id);
}