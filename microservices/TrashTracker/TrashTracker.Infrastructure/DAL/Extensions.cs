using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.DAL;
using TrashTracker.Core.Repositories;
using TrashTracker.Infrastructure.DAL.Context;
using TrashTracker.Infrastructure.DAL.Initializer;
using TrashTracker.Infrastructure.DAL.Repositories;

namespace TrashTracker.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPostgres<TrashTrackerDbContext>(configuration);
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IAlertzyIntegrationRepository, AlertzyIntegrationRepository>();
        services.AddScoped<ICollectionDateRepository, CollectionDateRepository>();
        services.AddScoped<IIntegrationLocalityRepository, IntegrationLocalityRepository>();
        services.AddScoped<ILocalityRepository, LocalityRepository>();
        services.AddScoped<IWasteTypeRepository, WasteTypeRepository>();
        return services;
    }
}