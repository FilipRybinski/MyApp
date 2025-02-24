namespace Shared.Core.RabbitMq;

public interface IRabbitMqPublisher
{
    Task PublishAsync<TRequest>(string name, TRequest body);
}