using CandyStore.Domain.CandyContext;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.DataAccess;

public class AppDbContext : DbContext
{
    internal DbSet<Candy> Candies { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder builder)
	{

	}
}
