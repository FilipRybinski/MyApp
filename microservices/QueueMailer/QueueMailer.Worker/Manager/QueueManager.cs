using System.Text;
using QueueMailer.Infrastructure.Connections.QueueDictionary;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace QueueMailer.Worker.Manager;

internal static class QueueManager
{
    
    private static IConnection? _connection;
    private static IChannel? _channel;

    public static async Task InitializeAsync()
    {
        if (_connection != null) return;
        var factory = new ConnectionFactory { HostName = QueueDictionary.Host };
        _connection = await factory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();
        await DeclareQueuesAsync();
    }
    
    private static async Task DeclareQueuesAsync()
    {
        if (_channel == null) return;
        foreach (var queue in QueueDictionary.Queues)
        {
            await _channel.QueueDeclareAsync(queue: queue.Key, durable: false, exclusive: false, autoDelete: false, arguments: null);
            await RegisterConsumersAsync(queue.Key, queue.Value);
        }
    }
    
    private static async Task RegisterConsumersAsync(string name, Func<string, Task> handler)
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