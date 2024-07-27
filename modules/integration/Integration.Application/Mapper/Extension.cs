using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Application.Mapper;

internal static class Extension
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}