using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using Shared.Application.RabbitMq;

namespace Shared.Infrastructure.RabbitMQ.RabbitMQBroadcaster;

internal class RabbitMqPublisher(IRabbitMqConnector rabbitMqConnector) : IRabbitMqPublisher
{
    public async Task PublishAsync<TRequest>(string exchange,string routingKey, TRequest body)
    {
        var channel = rabbitMqConnector.GetChannel();
        var serializedBody = SerializeBody(body);
        var props = new BasicProperties
        {
            DeliveryMode = DeliveryModes.Persistent
        };
        await channel.BasicPublishAsync(exchange: exchange, routingKey: routingKey,mandatory: true, basicProperties: props, body: serializedBody);
    }

    private static byte[] SerializeBody<TRequest>(TRequest body)
    {
        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(body));
    }
}