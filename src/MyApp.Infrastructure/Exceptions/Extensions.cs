using Microsoft.Extensions.DependencyInjection;
using MyApp.Infrastructure.Exceptions.Middleware;

namespace MyApp.Infrastructure.Exceptions;

internal static class Extensions
{
    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();
        return services;
    }
}