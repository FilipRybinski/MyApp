using Microsoft.Extensions.DependencyInjection;
using Shared.Exceptions.Middleware;

namespace Shared.Exceptions;

public static class Extensions
{
    public static IServiceCollection AddExceptionMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();
        return services;
    }
}