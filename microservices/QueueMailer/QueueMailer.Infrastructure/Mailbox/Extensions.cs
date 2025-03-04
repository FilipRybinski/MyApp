using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueMailer.Core.Options;
using QueueMailer.Infrastructure.Mailbox.Handlers;
using QueueMailer.Infrastructure.Mailbox.MailboxBroadcaster;
using QueueMailer.Infrastructure.Mailbox.MailboxConnection;
using QueueMailer.Infrastructure.Mailbox.MailboxMessage;
using Shared.Application;

namespace QueueMailer.Infrastructure.Mailbox;

internal static class Extensions
{
    private const string MailboxSectionName = "Mailbox";

    public static IServiceCollection AddMailbox(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailboxOptions>(configuration.GetRequiredSection(MailboxSectionName));
        services.AddSingleton<IMailboxConnector, MailboxConnector>();
        services.AddScopedHandler<IMailboxPublisher, MailboxPublisher>();
        services.AddScopedHandler<IMailboxMessageCreator, MailboxMessageCreator>();
        services.AddMailboxHandler();
        return services;
    }
}