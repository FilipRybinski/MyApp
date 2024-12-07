using Identity.Application.Handlers.IsAuthorized;
using Identity.Application.Handlers.Logout;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace Identity.Application.Handlers;

internal static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScopedHandler<IAuthorizedHandler, AuthorizedHandler>();
        services.AddScopedHandler<ILogoutHandler, LogoutHandler>();
        return services;
    }
}