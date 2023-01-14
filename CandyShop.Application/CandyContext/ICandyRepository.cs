using CandyStore.Domain.CandyContext;

namespace CandyStore.Infrastructure.DataAccess;

public interface ICandyRepository
{
    Task<List<Candy>> GetAsync();
    Task<Candy> GetAsync(long id);
    Task AddAsync(Candy candy);
    Task EditAsync(Candy candy);
    Task DeleteAsync(long id);
}
