using System.Reflection;
using Identity.Application.Handlers;
using Identity.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using Shared.CQRS;
using Shared.Mapper;

namespace Identity.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddCQRS(Assembly.GetExecutingAssembly());
        services.AddHandlers();
        services.AddMapper(Assembly.GetExecutingAssembly());
        services.AddValidators();
        return services;
    }
}