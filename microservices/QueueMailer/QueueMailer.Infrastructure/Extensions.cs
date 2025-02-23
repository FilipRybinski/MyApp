using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Infrastructure.Connections;
using Shared.Infrastructure;

namespace QueueMailer.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRabbitMqConnection();
        services.AddSharedInfrastructure(configuration);
        return services;
    }
}