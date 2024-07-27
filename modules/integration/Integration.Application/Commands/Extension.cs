using System.Reflection;
using Common.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Application.Commands;

internal static class Extension
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}