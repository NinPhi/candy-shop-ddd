using CandyStore.Application.CandyContext;
using CandyStore.DataAccess.Repositories;
using CandyStore.Cqrs.Requests;
using CandyStore.DataAccess;
using CandyCommandHandler = CandyStore.CommandHandlers.CandyContext.CandyHandler;
using CandyQueryHandler = CandyStore.QueryHandlers.CandyContext.CandyHandler;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CandyStore.Infrastructure.DependencyInjection;

public static class Configuration
{
    public static void RegisterAll(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .RegisterDbContext(configuration)
            .RegisterRepositories()
            .RegisterAppServices()
            .RegisterMediatR();
    }

    private static IServiceCollection RegisterDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CandyConnection");
        services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(connectionString));
        return services;
    }

    private static IServiceCollection RegisterRepositories(
        this IServiceCollection services)
    {
        services.AddTransient<ICandyRepository, CandyRepository>();
        return services;
    }

    private static IServiceCollection RegisterAppServices(
        this IServiceCollection services)
    {
        services.AddTransient<CandyService>();
        return services;
    }

    private static IServiceCollection RegisterMediatR(
        this IServiceCollection services)
    {
        services.AddMediatR(
            typeof(CandyCommandHandler).GetTypeInfo().Assembly,
            typeof(CandyQueryHandler).GetTypeInfo().Assembly,
            typeof(GetCandyQuery).GetTypeInfo().Assembly);

        return services;
    }
}
