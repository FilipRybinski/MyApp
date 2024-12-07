using FeatureFlags.Application.Handlers.GetFeatureFlags;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace FeatureFlags.Application.Handlers;

internal static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScopedHandler<IGetFeatureFlagsHandler, GetFeatureFlagsHandler>();
        return services;
    }
}