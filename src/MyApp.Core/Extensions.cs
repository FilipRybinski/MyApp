using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}