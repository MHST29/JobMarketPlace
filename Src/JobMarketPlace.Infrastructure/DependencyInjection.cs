using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Infrastructure.Persistence;
using JobMarketPlace.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobMarketPlace.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
           configuration.GetConnectionString("DefaultConnection")
           ?? throw new InvalidOperationException(
               "Connection string not found.");

        // PostgreSQL

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        // AppDbContext Interface

        services.AddScoped<IAppDbContext>(
            provider =>
                provider.GetRequiredService<AppDbContext>());

        // Redis

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration =
                configuration.GetConnectionString("Redis");

            options.InstanceName =
                "CommunityVersion";
        });

        services.AddScoped<
            ICacheService,
            RedisCacheService>();

        return services;
    }
}

