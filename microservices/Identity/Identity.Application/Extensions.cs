using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.CQRS;
using Shared.Application.Mapper;

namespace Identity.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddCQRS(Assembly.GetExecutingAssembly());
        services.AddMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}