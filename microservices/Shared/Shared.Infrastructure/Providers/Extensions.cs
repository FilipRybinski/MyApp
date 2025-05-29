using Microsoft.Extensions.DependencyInjection;
using Shared.Application.Providers;
using Shared.Application.Providers.Identity;
using Shared.Infrastructure.Providers.Identity;

namespace Shared.Infrastructure.Providers;

internal static class Extensions
{
    public static IServiceCollection AddProviders(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IIdentityProvider, IdentityProvider>();
        return services;
    }
}