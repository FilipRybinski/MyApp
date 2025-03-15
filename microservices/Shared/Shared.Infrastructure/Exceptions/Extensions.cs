using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Exceptions.Middleware;

namespace Shared.Infrastructure.Exceptions;

internal static class Extensions
{
    public static IServiceCollection AddExceptionMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();
        return services;
    }
}