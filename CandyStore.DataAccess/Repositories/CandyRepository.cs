using CandyStore.Application.CandyContext;
using CandyStore.Domain.CandyContext;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.DataAccess.Repositories;

public class CandyRepository : ICandyRepository
{
    private readonly AppDbContext context;

    internal CandyRepository(AppDbContext context)
    {
        this.context = context;
    }

    public Task<List<Candy>> AllAsync() =>
        context.Candies.AsNoTracking().ToListAsync();

    public Task<Candy?> SingleOrNullAsync(long id) =>
        context.Candies.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Candy> AddAsync(Candy candy) =>
        (await context.Candies.AddAsync(candy)).Entity;

    public Task EditAsync(Candy candy) =>
        Task.Run(() => context.Candies.Update(candy));

    public Task RemoveAsync(Candy candy) =>
        Task.Run(() => context.Candies.Remove(candy));
}
