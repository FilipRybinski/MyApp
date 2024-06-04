using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Infrastructure.Exceptions;

internal static class Extensions
{
    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();
        return services;
    }
}