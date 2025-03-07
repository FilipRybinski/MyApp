using RabbitMQ.Client;

namespace Shared.Application.RabbitMq;

public interface IRabbitMqConnector : IAsyncDisposable
{
    Task InitializeAsync();
    IChannel GetChannel();
}