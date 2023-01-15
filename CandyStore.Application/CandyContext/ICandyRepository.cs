using CandyStore.Application;
using CandyStore.Domain.CandyContext;

namespace CandyStore.Application.CandyContext;

public interface ICandyRepository : IRepository<Candy>
{
    public Task<List<Candy>> AllAsync();
    public Task<Candy?> FindOrNullAsync(long id);
    public Task<Candy> CreateAsync(Candy candy);
    public Task UpdateAsync(Candy candy);
    public Task DeleteAsync(Candy candy);
}
