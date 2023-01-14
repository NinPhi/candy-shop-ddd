using CandyShop.Application;
using CandyStore.Application.CandyContext;
using CandyStore.Domain.CandyContext;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.DataAccess.Repositories;

public class CandyRepository : Repository<Candy>, ICandyRepository
{
    internal CandyRepository(AppDbContext context) : base(context) { }

    public Task<List<Candy>> AllAsync() =>
        context.Candies.AsNoTracking().ToListAsync();

    public Task<Candy?> FindOrNullAsync(long id) =>
        context.Candies.FindAsync(id).AsTask();

    public async Task<Candy> CreateAsync(Candy candy) =>
        (await context.Candies.AddAsync(candy)).Entity;

    public Task UpdateAsync(Candy candy) =>
        Task.Run(() => context.Candies.Update(candy));

    public Task DeleteAsync(Candy candy) =>
        Task.Run(() => context.Candies.Remove(candy));
}
