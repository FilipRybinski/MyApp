using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Infrastructure.DAL;
using QueueMailer.Infrastructure.Mailbox;
using QueueMailer.Infrastructure.RabbitMQ;
using Shared.Infrastructure;

namespace QueueMailer.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddQueueMailerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMailbox(configuration);
        services.AddPostgres(configuration);
        services.AddMassTransitRabbitMq(configuration);
        services.AddSharedInfrastructure(configuration);
        return services;
    }
}