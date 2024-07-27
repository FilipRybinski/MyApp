using System.Reflection;
using Common.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.Application.Queries;

internal static class Extension
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}