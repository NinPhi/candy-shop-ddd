using CandyStore.Application.CandyContext;
using CandyStore.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CandyStore.Infrastructure.DependencyInjection;

public static class Configuration
{
    public static void RegisterAll(
        this IServiceCollection services)
    {
        services.RegisterRepositories();
    }

    private static IServiceCollection RegisterRepositories(
        this IServiceCollection services)
    {
        services.AddTransient<ICandyRepository, CandyRepository>();
        return services;
    }
}
