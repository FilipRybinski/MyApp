using QueueMailer.Application.Commands.SendResetPasswordEmail;
using QueueMailer.Core.Abstractions;
using QueueMailer.Infrastructure.Mailbox.MailboxBroadcaster;
using QueueMailer.Infrastructure.Mailbox.MailboxMessage;

namespace QueueMailer.Infrastructure.Mailbox.Handlers.ResetPasswordEmailHandler;

internal class ResetPasswordEmailMailboxHandler(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : IMailboxHandler<ResetPasswordEmail>
{
    public async Task HandleAsync(ResetPasswordEmail command)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(command.Email));
    }
}