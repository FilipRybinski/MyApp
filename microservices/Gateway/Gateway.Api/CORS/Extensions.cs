using Shared.Core.Configuration;
using Shared.Infrastructure;

namespace Gateway.Api.CORS;

internal static class Extensions
{
    private static CorsConfiguration corsConfiguration;
    public static IServiceCollection AddCORS(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsConfiguration>(configuration.GetRequiredSection(nameof(CorsConfiguration)));
        corsConfiguration = configuration.GetOptions<CorsConfiguration>(nameof(CorsConfiguration));

        return services;
    }

    public static WebApplication UseCORS(this WebApplication app)
    {
        app.UseCors(x => x.WithOrigins(corsConfiguration.ConnectionUrls)
            .AllowAnyHeader()
            .WithMethods(corsConfiguration.AllowedMethods)
            .SetIsOriginAllowed(origins => corsConfiguration.ConnectionUrls.Any(origins.StartsWith))
            .AllowCredentials());

        return app;
    }
}