using MimeKit;
using QueueMailer.Infrastructure.Mailbox.MailboxConnection;

namespace QueueMailer.Infrastructure.Mailbox.MailboxBroadcaster;

internal class MailboxPublisher(IMailboxConnector mailboxConnector) : IMailboxPublisher
{
    public async Task PublishAsync(MimeMessage message)
    {
        var mailbox = await mailboxConnector.GetSmtpClient();
        try
        {
            await mailbox.SendAsync(message);
        }
        catch
        {
            throw new Exception($"Mailbox publisher failed for {message.Subject}");
        }
    }
}