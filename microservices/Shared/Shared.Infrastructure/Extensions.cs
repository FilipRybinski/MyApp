using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.Routes;
using Shared.Core.Configuration;
using Shared.Infrastructure.AppCulture;
using Shared.Infrastructure.AppRoutes;
using Shared.Infrastructure.Authorization;
using Shared.Infrastructure.Documentation;
using Shared.Infrastructure.Exceptions;
using Shared.Infrastructure.Exceptions.Middleware;
using Shared.Infrastructure.Providers;

namespace Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CookieSettingsConfiguration>(configuration.GetRequiredSection(nameof(CookieSettingsConfiguration)));
        services.Configure<RoutesConfiguration>(configuration.GetRequiredSection(nameof(RoutesConfiguration)));
        services.AddDocumentation();
        
        services.ConfigureAuthorization(configuration);
        services.AddExceptionMiddleware();
        services.AddSingleton<IRoutes, Routes>();
        services.AddProviders();

        return services;
    }

    public static WebApplication UseSharedInfrastructure(this WebApplication app)
    {
        Culture.ConfigureCulture("en");
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

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