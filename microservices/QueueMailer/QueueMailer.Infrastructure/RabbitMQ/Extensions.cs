using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Infrastructure.RabbitMQ.QueuesDefinition;
using Shared.Core.Abstractions;

namespace QueueMailer.Infrastructure.RabbitMQ;

internal static class Extensions
{
    public static IServiceCollection AddQueuesDefinition(this IServiceCollection services)
    {
        services.AddScoped<IQueuesDefinition, Queues>();
        return services;
    }
}