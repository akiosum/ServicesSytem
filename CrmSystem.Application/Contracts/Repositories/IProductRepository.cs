using CrmSystem.Application.Entities;

namespace CrmSystem.Application.Contracts.Repositories;

public interface IProductRepository
{
    Task<Product> Add(Product product, CancellationToken cancellationToken = default);
    Task<Product> Update(Product product, CancellationToken cancellationToken = default);
    Task<Product?> GetById(Guid id);
}