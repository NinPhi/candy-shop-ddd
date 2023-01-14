using CandyStore.Domain.CandyContext;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Candy> Candies { get; private set; }

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{

	}
}
