using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Abstractions;

namespace MyApp.Application.Queries;

internal static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(typeof(IQueryHandler<,>).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}