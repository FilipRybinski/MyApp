using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands;

internal static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(typeof(ICommandHandler<>).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}