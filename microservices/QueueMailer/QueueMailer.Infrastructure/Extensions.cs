using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Infrastructure.Mailbox;
using QueueMailer.Infrastructure.RabbitMQ;
using Shared.Core.Abstractions;
using Shared.Infrastructure;
using Shared.Infrastructure.RabbitMQ;

namespace QueueMailer.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMailbox(configuration);
        services.AddQueuesDefinition();
        services.AddRabbitMqWorker(configuration,
            services.BuildServiceProvider().GetRequiredService<IQueuesDefinition>().Definition);
        services.AddSharedInfrastructure(configuration);
        return services;
    }
}