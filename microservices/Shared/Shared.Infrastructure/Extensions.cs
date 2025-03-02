using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequestClient;
using Shared.Core.Options;
using Shared.Infrastructure.Authorization;
using Shared.Infrastructure.Exceptions;
using Shared.Infrastructure.Exceptions.Middleware;

namespace Shared.Infrastructure;

public static class Extensions
{
    private const string SectionName = "url";
    private const string CookieSettingsSectionName = "cookieSettings";
    private static CorsOptions CorsOptions;

    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsOptions>(configuration.GetRequiredSection(SectionName));
        services.Configure<CookieSettingsOptions>(configuration.GetRequiredSection(CookieSettingsSectionName));
        CorsOptions = configuration.GetOptions<CorsOptions>(SectionName);
        
        services.ConfigureAuthorization(configuration);
        services.AddExceptionMiddleware();
        services.AddRequestClient();

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
        app.UseCors(x => x.WithOrigins(CorsOptions.ConnectionUrls)
            .AllowAnyHeader()
            .WithMethods(CorsOptions.AllowedMethods)
            .SetIsOriginAllowed(origins => CorsOptions.ConnectionUrls.Any(origins.StartsWith))
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