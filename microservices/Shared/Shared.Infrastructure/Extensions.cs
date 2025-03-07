using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequestClient;
using Shared.Application.Routes;
using Shared.Core.Configuration;
using Shared.Infrastructure.Authorization;
using Shared.Infrastructure.Exceptions;
using Shared.Infrastructure.Exceptions.Middleware;

namespace Shared.Infrastructure;

public static class Extensions
{
    private static CorsConfiguration corsConfiguration;
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsConfiguration>(configuration.GetRequiredSection(nameof(CorsConfiguration)));
        services.Configure<CookieSettingsConfiguration>(configuration.GetRequiredSection(nameof(CookieSettingsConfiguration)));
        services.Configure<RoutesConfiguration>(configuration.GetRequiredSection(nameof(RoutesConfiguration)));
        corsConfiguration = configuration.GetOptions<CorsConfiguration>(nameof(CorsConfiguration));
        
        services.ConfigureAuthorization(configuration);
        services.AddExceptionMiddleware();
        services.AddRequestClient();
        services.AddSingleton<IRoutes, Routes.Routes>();

        return services;
    }

    public static WebApplication UseSharedInfrastructure(this WebApplication app)
    {
        Culture.Culture.ConfigureCulture("en");
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCors(x => x.WithOrigins(corsConfiguration.ConnectionUrls)
            .AllowAnyHeader()
            .WithMethods(corsConfiguration.AllowedMethods)
            .SetIsOriginAllowed(origins => corsConfiguration.ConnectionUrls.Any(origins.StartsWith))
            .AllowCredentials());

        return app;
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);
        return options;
    }
}