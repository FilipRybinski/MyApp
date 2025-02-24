using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Options;
using Shared.Core.RabbitMq;
using Shared.Infrastructure.RabbitMQ.RabbitMQBackgroundWorker;
using Shared.Infrastructure.RabbitMQ.RabbitMQBroadcaster;
using Shared.Infrastructure.RabbitMQ.RabbitMQConnection;

namespace Shared.Infrastructure.RabbitMQ;

public static class Extensions
{
    private const string rabbitMQSectionName = "rabbitMq";
    private static RabbitMqOptions rabbitMqOptions;
    public static IServiceCollection AddRabbitMqWorker(this IServiceCollection services,IConfiguration configuration,Dictionary<string, Func<string, Task>> queues)
    {
        services.Configure<RabbitMqOptions>(configuration.GetRequiredSection(rabbitMQSectionName));
        rabbitMqOptions = configuration.GetOptions<RabbitMqOptions>(rabbitMQSectionName);
        
        services.AddSingleton<IRabbitMqConnector>(s => new RabbitMqConnector(rabbitMqOptions,queues));
        services.AddScoped<IRabbitMqPublisher, RabbitMqPublisher>();
        services.AddHostedService<RabbitMqWorker>();
        return services;
    }
}