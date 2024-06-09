using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Abstractions;
using MyApp.Application.Mapper;
using MyApp.Application.Validators;

namespace MyApp.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(typeof(ICommandHandler<>).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(s => s.FromAssemblies(typeof(IQueryHandler<,>).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddMapper();
        services.AddValidators();
        return services;
    }
}