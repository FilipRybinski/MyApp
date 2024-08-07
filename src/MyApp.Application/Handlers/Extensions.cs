using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Handlers.GetFeatureFlags;
using MyApp.Application.Handlers.IsAuthorized;
using MyApp.Application.Handlers.Logout;

namespace MyApp.Application.Handlers;

public static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScopedHandler<IGetFeatureFlagsHandler, GetFeatureFlagsHandler>();
        services.AddScopedHandler<IAuthorizedHandler, AuthorizedHandler>();
        services.AddScopedHandler<ILogoutHandler, LogoutHandler>();
        return services;
    }

    private static IServiceCollection AddScopedHandler<TInterface, TClass>(this IServiceCollection services)
        where TClass : class, TInterface where TInterface : class => services.AddScoped<TInterface, TClass>();
}