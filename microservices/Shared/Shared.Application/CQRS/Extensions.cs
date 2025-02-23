using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Abstractions;

namespace Shared.Application.CQRS;

public static class Extensions
{
    public static IServiceCollection AddCQRS(this IServiceCollection services,Assembly assembly)
    {
        services.AddCommands(assembly);
        services.AddQueries(assembly);
        return services;
    }
    
    private static IServiceCollection AddCommands(this IServiceCollection services,Assembly assembly)
    {
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
    
    private static IServiceCollection AddQueries(this IServiceCollection services,Assembly assembly)
    {
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}