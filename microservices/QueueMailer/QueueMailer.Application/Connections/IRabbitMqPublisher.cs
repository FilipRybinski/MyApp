namespace QueueMailer.Application.Connections;

public interface IRabbitMqPublisher
{
    public Task PublishAsync<TRequest>(string name, TRequest body);
}