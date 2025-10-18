using Identity.Application.Abstractions.Security;
using Identity.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace Identity.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<UserIdentity>, PasswordHasher<UserIdentity>>()
            .AddSingleton<IPasswordManager, PasswordManager>();
        
        return services;
    }
}