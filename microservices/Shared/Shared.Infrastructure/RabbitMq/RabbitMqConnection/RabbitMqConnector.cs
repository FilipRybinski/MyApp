using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Core.Options;
using Shared.Core.RabbitMq;

namespace Shared.Infrastructure.RabbitMQ.RabbitMQConnection;

internal class RabbitMqConnector(RabbitMqOptions options,Dictionary<string, Func<string, Task>> queues) : IRabbitMqConnector
{
    private IConnection? _connection;
    private IChannel? _channel;
    
    public async Task InitializeAsync()
    {
        if (_connection != null) return;
        var factory = new ConnectionFactory { HostName = options.Host};
        _connection = await factory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();
        await DeclareQueuesAsync();
    }

    public IChannel GetChannel() => _channel;

    public async ValueTask DisposeAsync()
    {
        if (_channel != null)
        {
            await _channel.CloseAsync();
            await _channel.DisposeAsync();
        }
        
        if (_connection != null)
        {
            await _connection.CloseAsync();
            await _connection.DisposeAsync();
        }
    }
    
    private async Task DeclareQueuesAsync()
    {
        if (_channel == null) return;
        foreach (var queue in queues)
        {
            await _channel.QueueDeclareAsync(
                queue: queue.Key, 
                durable: true, 
                exclusive: false, 
                autoDelete: false, 
                arguments: null);
            await RegisterConsumersAsync(queue.Key, queue.Value);
        }
    }
    
    private async Task RegisterConsumersAsync(string name, Func<string, Task> handler)
    {
        if (_channel == null) return;
        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += async (model, ea) => await ResponseConverter(ea, handler);
        await _channel.BasicConsumeAsync(queue: name, autoAck: true, consumer: consumer);
    }

    private static async Task ResponseConverter(BasicDeliverEventArgs ea,Func<string, Task> handler)
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        await handler(message);
    }
}