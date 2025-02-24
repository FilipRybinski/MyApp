using Microsoft.Extensions.Hosting;
using Shared.Core.RabbitMq;

namespace Shared.Infrastructure.RabbitMQ.RabbitMQBackgroundWorker;

internal class RabbitMqWorker(IRabbitMqConnector rabbitMqConnector) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await rabbitMqConnector.InitializeAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await rabbitMqConnector.DisposeAsync();
    }
}