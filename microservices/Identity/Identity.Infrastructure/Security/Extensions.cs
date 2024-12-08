using Identity.Application.Security;
using Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace Identity.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<_Identity>, PasswordHasher<_Identity>>()
            .AddSingleton<IPasswordManager, PasswordManager>();
        
        return services;
    }
}