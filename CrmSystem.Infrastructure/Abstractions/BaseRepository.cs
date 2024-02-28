using CrmSystem.Infrastructure.Data;

namespace CrmSystem.Infrastructure.Abstractions;

public abstract class BaseRepository<TEntity> : IBaseRepository
    where TEntity : class
{
    #region Properties

    protected readonly ApplicationDbContext DbContext;

    #endregion Properties

    #region Constructors

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    #endregion Constructors

    protected async Task<TEntity> AddContext(TEntity entity, CancellationToken cancellationToken)
    {
        DbContext
            .Set<TEntity>()
            .Add(entity);
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async Task<TEntity> UpdateContext(TEntity entity, CancellationToken cancellationToken)
    {
        DbContext
            .Set<TEntity>()
            .Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async Task<TEntity?> GetByIdContext(Guid id)
    {
        TEntity? entity = await DbContext
            .Set<TEntity>()
            .FindAsync(id);

        return entity;
    }
}