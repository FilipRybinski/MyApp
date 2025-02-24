using RabbitMQ.Client;

namespace Shared.Core.RabbitMq;

public interface IRabbitMqConnector : IAsyncDisposable
{
    Task InitializeAsync();
    IChannel GetChannel();
}