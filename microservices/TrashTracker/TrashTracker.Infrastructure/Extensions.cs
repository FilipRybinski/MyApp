using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequestClient;
using Shared.Infrastructure;
using TrashTracker.Infrastructure.DAL;
using TrashTracker.Infrastructure.Synchronizer;

namespace TrashTracker.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddTrashTrackerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddRequestClient();
        services.AddSynchronizer(configuration);
        services.AddSharedInfrastructure(configuration);
        return services;
    }
    
}