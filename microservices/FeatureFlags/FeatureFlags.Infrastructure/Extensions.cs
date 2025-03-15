using FeatureFlags.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure;

namespace FeatureFlags.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FeatureFlagsConfiguration>(configuration.GetRequiredSection(nameof(FeatureFlagsConfiguration)));
        services.AddHttpContextAccessor();
        services.AddSharedInfrastructure(configuration);
        
        return services;
    }
}