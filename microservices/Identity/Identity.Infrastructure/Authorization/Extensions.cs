using Identity.Application.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Authorization;

namespace Identity.Infrastructure.Authorization;

internal static class Extensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services
            .AddSingleton<IAuthenticator, Authenticator>()
            .AddSingleton<IHttpContextTokenService, HttpContextTokenService>();
        return services;
    }
}