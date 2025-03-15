using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Core.Configuration;
using QueueMailer.Infrastructure.Mailbox.Handlers;
using QueueMailer.Infrastructure.Mailbox.MailboxBroadcaster;
using QueueMailer.Infrastructure.Mailbox.MailboxConnection;
using QueueMailer.Infrastructure.Mailbox.MailboxMessage;
using Shared.Application;

namespace QueueMailer.Infrastructure.Mailbox;

internal static class Extensions
{
    public static IServiceCollection AddMailbox(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailboxConfiguration>(configuration.GetRequiredSection(nameof(MailboxConfiguration)));
        services.AddSingleton<IMailboxConnector, MailboxConnector>();
        services.AddScoped<IMailboxPublisher, MailboxPublisher>();
        services.AddScoped<IMailboxMessageCreator, MailboxMessageCreator>();
        services.AddMailboxHandler();
        return services;
    }
}