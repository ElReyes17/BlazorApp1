using Application.Interfaces.Repositories.Categories;
using Application.Interfaces.Services.Categories;
using Application.ViewModels.Categories;

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
            
            CategoryName = a.CategoryName

        }).ToList();

        return list;
    }

    public async Task<CategoryViewModel> GetById(int id)
    {
        var get = await _repository.GetById(id);

        CategoryViewModel category = new CategoryViewModel
        {
            CategoryName = get.CategoryName
        };

        return category;
        
    }
    public Task Add(SaveCategoryViewModel product)
    {
        throw new NotImplementedException();
    }


    public Task Update(SaveCategoryViewModel product, int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}
