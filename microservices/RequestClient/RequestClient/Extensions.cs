using Microsoft.Extensions.DependencyInjection;
using RequestClient.Handler;


namespace RequestClient;

public static class Extensions
{
    public static IServiceCollection AddRequestClient(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IRequestHandler,RequestHandler>();
        return services;
    }
}