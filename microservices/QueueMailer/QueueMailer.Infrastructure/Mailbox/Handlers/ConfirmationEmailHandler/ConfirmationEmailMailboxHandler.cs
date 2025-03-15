using QueueMailer.Application.Commands.SendConfirmationEmail;
using QueueMailer.Core.Abstractions;
using QueueMailer.Infrastructure.Mailbox.MailboxBroadcaster;
using QueueMailer.Infrastructure.Mailbox.MailboxMessage;

namespace QueueMailer.Infrastructure.Mailbox.Handlers.ConfirmationEmailHandler;

internal sealed class ConfirmationEmailMailboxHandler(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : IMailboxHandler<ConfirmationEmail>
{
    public async Task HandleAsync(ConfirmationEmail command, CancellationToken cancellationToken) =>
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(command.Email));
}