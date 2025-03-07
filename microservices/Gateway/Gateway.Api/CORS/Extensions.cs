using Shared.Core.Configuration;
using Shared.Infrastructure;

namespace Gateway.Api.CORS;

public static class Extensions
{
    private static CorsConfiguration corsConfiguration;
    
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsConfiguration>(configuration.GetRequiredSection(nameof(CorsConfiguration)));
        corsConfiguration = configuration.GetOptions<CorsConfiguration>(nameof(CorsConfiguration));
        return services;
    }
    
    public static WebApplication UseCorsPolicy(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseCors(x => x.WithOrigins(corsConfiguration.ConnectionUrls)
            .AllowAnyHeader()
            .WithMethods(corsConfiguration.AllowedMethods)
            .SetIsOriginAllowed(origins => corsConfiguration.ConnectionUrls.Any(origins.StartsWith))
            .AllowCredentials());
        app.MapReverseProxy();

        return app;
    }
}