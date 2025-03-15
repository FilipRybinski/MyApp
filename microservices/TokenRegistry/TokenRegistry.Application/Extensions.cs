using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.CQRS;

namespace TokenRegistry.Application;

public static class Extensions
{
    public static IServiceCollection AddTokenRegistryApplication(this IServiceCollection services)
    {

        services.AddCQRS(Assembly.GetExecutingAssembly());
        return services;
    }
}