using Microsoft.Extensions.DependencyInjection;
using MyApp.Infrastructure.DAL;

namespace MyApp.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPostgres();
        return services;
    }
}