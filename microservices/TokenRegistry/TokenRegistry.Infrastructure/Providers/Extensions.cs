using Microsoft.Extensions.DependencyInjection;
using TokenRegistry.Core.Providers;
using TokenRegistry.Infrastructure.Providers.Token;

namespace TokenRegistry.Infrastructure.Providers;

internal static class Extensions
{
    public static IServiceCollection AddProviders(this IServiceCollection services)
    {
        services.AddScoped<ITokenProvider, TokenProvider>();
        return services;
    }
}