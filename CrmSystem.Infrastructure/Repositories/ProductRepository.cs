using CrmSystem.Application.Contracts.Repositories;
using CrmSystem.Application.Entities;
using CrmSystem.Infrastructure.Abstractions;
using CrmSystem.Infrastructure.Data;

namespace CrmSystem.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    #region Constructrors

    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    #endregion Constructrors

    public async Task<Product> Add(Product product, CancellationToken cancellationToken = default)
    {
        return await AddContext(product, cancellationToken);
    }

    public async Task<Product> Update(Product product, CancellationToken cancellationToken = default)
    {
        return await UpdateContext(product, cancellationToken);
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await GetByIdContext(id);
    }
}