using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure;

namespace TokenRegistry.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddTokenRegistryInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharedInfrastructure(configuration);
        return services;
    }
}