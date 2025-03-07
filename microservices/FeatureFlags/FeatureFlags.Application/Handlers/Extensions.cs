using FeatureFlags.Application.Handlers.GetFeatureFlags;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application;

namespace FeatureFlags.Application.Handlers;

internal static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IGetFeatureFlagsHandler, GetFeatureFlagsHandler>();
        return services;
    }
}