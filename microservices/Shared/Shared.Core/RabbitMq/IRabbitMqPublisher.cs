namespace Shared.Core.RabbitMq;

public interface IRabbitMqPublisher
{
    Task PublishAsync<TRequest>(string exchange,string routingKey, TRequest body);
}