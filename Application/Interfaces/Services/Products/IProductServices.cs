namespace Application.Interfaces.Services.Products;
using Application.ViewModels.Products;

public interface IProductServices
{
    Task<List<ProductViewModel>> GetAll();

    Task<ProductViewModel> GetById(int id);

    Task Add(SaveProductViewModel product);

    Task Update(SaveProductViewModel product, int id);

    Task Delete(int id);
}