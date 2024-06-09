using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Application.Mapper;

internal static class Extensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}