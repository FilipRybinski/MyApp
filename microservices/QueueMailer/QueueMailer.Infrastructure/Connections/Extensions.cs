using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Application.Connections;
using QueueMailer.Infrastructure.Connections.QueueConnector;
using QueueMailer.Infrastructure.Connections.QueuePublisher;

namespace QueueMailer.Infrastructure.Connections;

public static class Extensions
{
    public static IServiceCollection AddRabbitMqConnection(this IServiceCollection services)
    {
        services.AddSingleton<IRabbitMqConnector, RabbitMqConnector>();
        services.AddScoped<IRabbitMqPublisher, RabbitMqPublisher>();
        return services;
    }
}