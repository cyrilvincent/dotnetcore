using FormationASPNETCore.Entities;
using FormationASPNETCore.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormationASPNETCore.Services;

public abstract class AEntityService<TEntity> : IDisposable, IAsyncDisposable where TEntity : class, IEntity
{
    protected readonly FormationDbContext dbContext;
    protected readonly ILogger logger;

    protected AEntityService(FormationDbContext dbContext, ILogger logger)
    {
        this.dbContext = dbContext;
        this.logger = logger;
    }

    public async Task<T> Add<T>(T entity) where T : class, IEntity
    {
        await dbContext.AddAsync(entity);
        return entity;
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        return await Add<TEntity>(entity);
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        return await Update<TEntity>(entity);
    }

    public async Task<T> Update<T>(T entity) where T : class, IEntity
    {
        T? entityFound = await dbContext.FindAsync<T>(entity.Id);
        if (entityFound == null) throw new NotFoundException("not found");

        dbContext.Set<T>().Attach(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    public async Task<TEntity> Delete(long id)
    {
        TEntity? entityFound = await dbContext.FindAsync<TEntity>(id);
        if (entityFound == null) throw new NotFoundException("not found");

        dbContext.Remove(entityFound);
        return entityFound;
    }

    public async Task Save()
    {
        await dbContext.SaveChangesAsync();
    }

    public ValueTask DisposeAsync()
    {
        return dbContext.DisposeAsync();
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}