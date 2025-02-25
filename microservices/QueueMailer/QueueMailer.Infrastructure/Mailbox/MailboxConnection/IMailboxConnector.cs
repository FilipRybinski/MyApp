using MailKit.Net.Smtp;

namespace QueueMailer.Infrastructure.Mailbox.MailboxConnection;

internal interface IMailboxConnector : IAsyncDisposable
{
    public Task<SmtpClient> GetSmtpClient();
}