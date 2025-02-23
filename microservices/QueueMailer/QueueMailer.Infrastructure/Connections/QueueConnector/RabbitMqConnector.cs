using Microsoft.EntityFrameworkCore.Metadata;
using QueueMailer.Application.Connections;
using RabbitMQ.Client;

namespace QueueMailer.Infrastructure.Connections.QueueConnector;

internal class RabbitMqConnector : IRabbitMqConnector, IAsyncDisposable
{
    private IConnection? _connection = null;
    private IChannel? _channel = null;
    
    public async Task<IChannel?> GetRabbitMqConnection()
    {
        if (_connection is null)
        {
            var factory = new ConnectionFactory { HostName = QueueDictionary.QueueDictionary.Host };
            _connection = await factory.CreateConnectionAsync();
        }

        if (_channel is null)
        {
            _channel = await _connection.CreateChannelAsync();
        }
      
        return _channel;
    }

    public async ValueTask DisposeAsync()
    {
        if (_connection != null)
        {
            await _connection.CloseAsync();
            await _connection.DisposeAsync();
        }
    }
}