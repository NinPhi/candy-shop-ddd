using CandyStore.Domain.CommonContext;

namespace CandyStore.Application;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    public List<TEntity> Tracked();
    public List<TEntity> Tracked(Func<TEntity, bool> predicate);
    public Task SaveChangesAsync();
}
