using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace TokenRegistry.Infrastructure.DAL.Context;

internal static class Extensions
{
    public static IServiceCollection AddRedisDbContext(this IServiceCollection services)
    {
        services.AddScoped<IDatabase>(provider =>
        {
            var multiplexer = provider.GetRequiredService<IConnectionMultiplexer>();
            return multiplexer.GetDatabase();
        });
        return services;
    }
}