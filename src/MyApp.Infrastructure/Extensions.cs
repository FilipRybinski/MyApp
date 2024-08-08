using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Infrastructure.Auth;
using MyApp.Infrastructure.DAL;
using MyApp.Infrastructure.Exceptions;
using MyApp.Infrastructure.Exceptions.Middleware;
using MyApp.Infrastructure.Security;

namespace MyApp.Infrastructure;

public static class Extensions
{
    private const string SectionName = "url";
    private static CorsOptions CorsOptions;

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CorsOptions>(configuration.GetRequiredSection(SectionName));
        CorsOptions = configuration.GetOptions<CorsOptions>(SectionName);

        services.AddPostgres(configuration);
        services.AddSecurity();
        services.AddAuth(configuration);
        services.AddMiddleware();
        services.AddHttpContextAccessor();

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        ConfigureCulture("en");
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCors(x => x.WithOrigins(CorsOptions.ConnectionUrl)
            .AllowAnyHeader()
            .WithMethods(CorsOptions.AllowedMethods)
            .SetIsOriginAllowed(origin => origin.StartsWith(CorsOptions.ConnectionUrl))
            .AllowCredentials());

        return app;
    }

    private static void ConfigureCulture(string language)
    {
        var culture = new CultureInfo(language);
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}