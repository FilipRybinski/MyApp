using Identity.Infrastructure.Authorization;
using Identity.Infrastructure.DAL;
using Identity.Infrastructure.Options;
using Identity.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using Shared.CORS;
using Shared.Culture;
using Shared.Exceptions;
using Shared.Exceptions.Middleware;

namespace Identity.Infrastructure;

public static class Extensions
{
    private const string SectionName = "url";
    private const string CookieSettingsSectionName = "cookieSettings";
    private static CorsOptions CorsOptions;

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsOptions>(configuration.GetRequiredSection(SectionName));
        services.Configure<CookieSettingsOptions>(configuration.GetRequiredSection(CookieSettingsSectionName));
        CorsOptions = configuration.GetOptions<CorsOptions>(SectionName);

        services.AddPostgres(configuration);
        services.AddSecurity();
        services.AddAuth(configuration);
        services.AddExceptionMiddleware();
        services.AddHttpContextAccessor();

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        Culture.ConfigureCulture("en");
        app.UseMiddleware<ExceptionMiddleware>();
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
}