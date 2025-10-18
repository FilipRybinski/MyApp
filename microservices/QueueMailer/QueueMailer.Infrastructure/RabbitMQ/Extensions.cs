using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Infrastructure.DAL.Context;
using QueueMailer.Infrastructure.RabbitMQ.Consumers;
using Shared.Core.Configuration;
using Shared.Infrastructure;

namespace QueueMailer.Infrastructure.RabbitMQ;

internal static class Extensions
{
    public static IServiceCollection AddMassTransitRabbitMq(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<RabbitMqConfiguration>(configuration.GetRequiredSection(nameof(RabbitMqConfiguration)));
        var rabbitMqConfiguration = configuration.GetOptions<RabbitMqConfiguration>(nameof(RabbitMqConfiguration));

        services.AddMassTransit(config =>
        {
            config.AddConsumer<ConfirmationEmailEventConsumer>();
            config.AddConsumer<ResetPasswordEmailEventConsumer>();
            config.AddConsumer<ActivationEmailEventConsumer>();
            config.AddConsumer<PasswordSubmissionEmailEventConsumer>();

            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqConfiguration.Host);
                cfg.ConfigureEndpoints(context);
                cfg.AutoDelete = true;
                cfg.Durable = false;
            });

            config.AddConfigureEndpointsCallback((context, name, cfg) =>
            {
                cfg.UseEntityFrameworkOutbox<QueueMailerDbContext>(context);
            });

            config.AddEntityFrameworkOutbox<QueueMailerDbContext>(cfg =>
            {
                cfg.QueryDelay = TimeSpan.FromSeconds(10);
                cfg.UsePostgres();
                cfg.UseBusOutbox();
            });
        });
        return services;
    }
}