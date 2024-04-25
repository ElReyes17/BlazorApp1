using Application.Interfaces.Repositories.Categories;
using Application.Interfaces.Repositories.Products;
using Application.Interfaces.Services.Products;
using Application.ViewModels.Products;
using Domain.Entities;

namespace Application.Services.Products;

public class ProductServices : IProductServices
{
    private readonly IProductRepository _repository;
    private readonly ICategoryRepository _categoryrepository;
    public ProductServices(IProductRepository repository, ICategoryRepository categoryRepository)
    {
        _repository = repository;
        _categoryrepository = categoryRepository;
        
           
           
    }
    public async Task<List<ProductViewModel>> GetAll()
    {
        var list = await _repository.GetAll();
        await _categoryrepository.GetAll();

        var result = list.Select(a => new ProductViewModel
        {
            Id = a.Id,
            ProductName = a.ProductName,
            CategoryName = a.Category.CategoryName

        }).ToList();

        return result;

    }

    public async Task<ProductViewModel> GetById(int id)
    {
        var value =await _repository.GetById(id);

        ProductViewModel map = new ProductViewModel
        {
            Id = id,
            ProductName = value.ProductName,
            CategoryName = value.Category.CategoryName
        };

        return map;
    }

    public async Task Add(SaveProductViewModel product)
    {
        Product newp = new Product();
         
        newp.ProductName = product.ProductName;
        newp.CategoryId = product.CategoryId;

        await _repository.Add(newp);
    }

    public async Task Update(SaveProductViewModel product, int id)
    {
        var get = await _repository.GetById(id);



        get.ProductName = product.ProductName;
        get.CategoryId = product.CategoryId;

       await _repository.Update(get, id);


    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}