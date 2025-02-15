using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Culture;
using Shared.Exceptions.Middleware;

namespace FeatureFlags.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsOptions>(configuration.GetRequiredSection(SectionName));
        services.Configure<CookieSettingsOptions>(configuration.GetRequiredSection(CookieSettingsSectionName));
        return services;
    }
    
}