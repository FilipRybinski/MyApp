using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using Shared.Core.RabbitMq;

namespace Shared.Infrastructure.RabbitMQ.RabbitMQBroadcaster;

internal class RabbitMqPublisher(IRabbitMqConnector rabbitMqConnector) : IRabbitMqPublisher
{
    public async Task PublishAsync<TRequest>(string name, TRequest body)
    {
        var channel = rabbitMqConnector.GetChannel();
        var serializedBody = SerializeBody(body);
        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: name, body: serializedBody);
    }

    private static byte[] SerializeBody<TRequest>(TRequest body)
    {
        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(body));
    }
}