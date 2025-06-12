using FeeTracker.Infrastructure.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequestClient;
using Shared.Infrastructure;

namespace FeeTracker.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddRequestClient();
        services.AddSharedInfrastructure(configuration);
        
        return services;
    }
}