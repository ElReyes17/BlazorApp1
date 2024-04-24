using Domain.Entities;

namespace Application.Interfaces.Repositories.Products;

public interface IProductRepository
{
    Task<List<Product>> GetAll();

    Task<Product> GetById(int id);

    Task Add(Product product);

    Task Update(Product product, int id);

    Task Delete(int id);
}