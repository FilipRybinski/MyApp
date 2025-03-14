using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Application.Mapper;

public static class Extensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services,Assembly assembly)
    {
        services.AddAutoMapper(assembly);
        return services;
    }
}