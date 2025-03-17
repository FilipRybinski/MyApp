using Identity.Application.Handlers.IsAuthorized;
using Identity.Application.Handlers.Logout;
using Identity.Application.Handlers.Token;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application;

namespace Identity.Application.Handlers;

internal static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizedHandler, AuthorizedHandler>();
        services.AddScoped<ILogoutHandler, LogoutHandler>();
        services.AddScoped<IRefreshTokenHandler, RefreshTokenHandler>();
        return services;
    }
}