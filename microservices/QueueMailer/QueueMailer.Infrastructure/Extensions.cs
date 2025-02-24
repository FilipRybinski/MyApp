using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Core.RabbitMQ.Dictionary;
using Shared.Infrastructure;
using Shared.Infrastructure.RabbitMQ;

namespace QueueMailer.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRabbitMqWorker(configuration, QueueDictionary.Queues);
        services.AddSharedInfrastructure(configuration);
        return services;
    }
}