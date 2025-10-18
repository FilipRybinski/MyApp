using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure;
using TokenRegistry.Infrastructure.DAL;

namespace TokenRegistry.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddTokenRegistryInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRedis(configuration);
        services.AddSharedInfrastructure(configuration);
        return services;
    }
}