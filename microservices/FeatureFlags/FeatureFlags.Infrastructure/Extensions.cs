using FeatureFlags.Core.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure;

namespace FeatureFlags.Infrastructure;

public static class Extensions
{
    private const string SectionName = "featureFlags";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FeatureFlagsDto>(configuration.GetRequiredSection(SectionName));
        services.AddHttpContextAccessor();
        services.AddSharedInfrastructure(configuration);
        
        return services;
    }
}