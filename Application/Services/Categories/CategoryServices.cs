using Application.Interfaces.Repositories.Categories;
using Application.Interfaces.Services.Categories;
using Application.ViewModels.Categories;
using Domain.Entities;

namespace Application.Services.Categories;

public class CategoryServices : ICategoryServices
{
    private readonly ICategoryRepository _repository;

    public CategoryServices(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoryViewModel>> GetAll()
    {
        var get = await _repository.GetAll();

        var list = get.Select(a => new CategoryViewModel
        {
            Id = a.Id,
            CategoryName = a.CategoryName

        }).ToList();

        return list;
    }

    public async Task<CategoryViewModel> GetById(int id)
    {
        var get = await _repository.GetById(id);

        CategoryViewModel category = new CategoryViewModel
        {
            Id= id,
            CategoryName = get.CategoryName
        };

        return category;
        
    }
    public async Task Add(SaveCategoryViewModel product)
    {
        Category newp = new Category();

        product.CategoryName = newp.CategoryName;
       

        await _repository.Add(newp);
    }


    public Task Update(SaveCategoryViewModel product, int id)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
       await _repository.Delete(id);
    }
}
