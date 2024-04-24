using Application.ViewModels.Categories;
using Application.ViewModels.Products;

namespace Application.Interfaces.Services.Categories;

public interface ICategoryServices
{
    Task<List<CategoryViewModel>> GetAll();

    Task<CategoryViewModel> GetById(int id);

    Task Add(SaveCategoryViewModel product);

    Task Update(SaveCategoryViewModel product, int id);

    Task Delete(int id);
}