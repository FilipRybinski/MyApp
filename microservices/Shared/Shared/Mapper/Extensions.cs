using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Mapper;

public static class Extensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}