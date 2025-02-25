using MimeKit;

namespace QueueMailer.Infrastructure.Mailbox.MailboxBroadcaster;

internal interface IMailboxPublisher
{
    public Task PublishAsync(MimeMessage message);
}