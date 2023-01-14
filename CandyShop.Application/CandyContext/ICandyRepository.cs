using CandyStore.Domain.CandyContext;

namespace CandyStore.Application.CandyContext;

public interface ICandyRepository
{
    public Task<List<Candy>> AllAsync();
    public Task<Candy?> SingleOrNullAsync(long id);
    public Task<Candy> AddAsync(Candy candy);
    public Task EditAsync(Candy candy);
    public Task RemoveAsync(Candy candy);
}
