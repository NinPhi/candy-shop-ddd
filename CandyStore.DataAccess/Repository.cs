using CandyStore.Application;
using CandyStore.Domain.CommonContext;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CandyStore.DataAccess;

public class Repository<TEntity> where TEntity : class, IEntity
{
    private protected readonly AppDbContext context;

    internal Repository(AppDbContext context)
    {
        this.context = context;
    }

    public List<TEntity> Tracked(Func<TEntity, bool> predicate)
    {
        var entities = context
            .ChangeTracker
            .Entries()
            .Where(e => e.Entity is TEntity)
            .Select(e => (TEntity)e.Entity)
            .Where(predicate)
            .ToList();

        return entities;
    }

    public List<TEntity> Tracked()
    {
        var entities = context
            .ChangeTracker
            .Entries()
            .Where(e => e.Entity is TEntity)
            .Select(e => (TEntity)e.Entity)
            .ToList();

        return entities;
    }

    public Task SaveChangesAsync() => context.SaveChangesAsync();
}
