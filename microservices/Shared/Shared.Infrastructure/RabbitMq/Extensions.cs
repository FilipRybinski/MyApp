using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.RabbitMq;
using Shared.Core.Configuration;
using Shared.Infrastructure.RabbitMQ.RabbitMQBackgroundWorker;
using Shared.Infrastructure.RabbitMQ.RabbitMQBroadcaster;
using Shared.Infrastructure.RabbitMQ.RabbitMQConnection;

namespace Shared.Infrastructure.RabbitMQ;

public static class Extensions
{
    private static RabbitMqConfiguration rabbitMqConfiguration;
    public static IServiceCollection AddRabbitMqWorker(this IServiceCollection services, IConfiguration configuration, Dictionary<string, Func<string, Task>> queues)
    {
        services.Configure<RabbitMqConfiguration>(configuration.GetRequiredSection(nameof(RabbitMqConfiguration)));
        rabbitMqConfiguration = configuration.GetOptions<RabbitMqConfiguration>(nameof(RabbitMqConfiguration));
        
        services.AddSingleton<IRabbitMqConnector>(s => new RabbitMqConnector(rabbitMqConfiguration,queues));
        services.AddScoped<IRabbitMqPublisher, RabbitMqPublisher>();
        services.AddHostedService<RabbitMqWorker>();
        return services;
    }
}