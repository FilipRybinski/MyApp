using RabbitMQ.Client;

namespace QueueMailer.Application.Connections;

public interface IRabbitMqConnector
{
    Task<IChannel?> GetRabbitMqConnection();
}