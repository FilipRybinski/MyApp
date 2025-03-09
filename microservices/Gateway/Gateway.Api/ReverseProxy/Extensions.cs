using Gateway.Api.CORS;

namespace Gateway.Api.ReverseProxy;

internal static class Extensions
{
    public static IServiceCollection AddReverseProxy(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCORS(configuration);
        services.AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"));
        
        return services;
    }
    
    public static WebApplication UseReverseProxy(this WebApplication app)
    {
        app.UseCORS();
        app.MapReverseProxy();

        return app;
    }
}