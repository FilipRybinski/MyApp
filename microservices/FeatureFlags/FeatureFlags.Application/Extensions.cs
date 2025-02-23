using FeatureFlags.Application.Handlers;
using Microsoft.Extensions.DependencyInjection;


namespace FeatureFlags.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddHandlers();
        return services;
    }
}