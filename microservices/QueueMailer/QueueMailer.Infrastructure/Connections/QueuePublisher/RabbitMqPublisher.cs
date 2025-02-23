using System.Text;
using System.Text.Json;
using QueueMailer.Application.Connections;
using RabbitMQ.Client;

namespace QueueMailer.Infrastructure.Connections.QueuePublisher;

internal class RabbitMqPublisher(IRabbitMqConnector rabbitMqConnector) : IRabbitMqPublisher
{
    public async Task PublishAsync<TRequest>(string name, TRequest body)
    {
        var channel = await rabbitMqConnector.GetRabbitMqConnection();
        var serializedBody = SerializeBody(body);
        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: name, body: serializedBody);
    }

    private static byte[] SerializeBody<TRequest>(TRequest body)
    {
        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(body));
    }
}