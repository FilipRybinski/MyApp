using Microsoft.Extensions.DependencyInjection;

namespace Integration.Application.Handlers;

internal static class Extension
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddScopedHandler<TInterface, TClass>(this IServiceCollection services)
        where TClass : class, TInterface where TInterface : class => services.AddScoped<TInterface, TClass>();
}