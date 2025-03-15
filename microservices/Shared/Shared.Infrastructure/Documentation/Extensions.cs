using Microsoft.Extensions.DependencyInjection;

namespace Shared.Infrastructure.Documentation;

internal static class Extensions
{
    public static IServiceCollection AddDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}