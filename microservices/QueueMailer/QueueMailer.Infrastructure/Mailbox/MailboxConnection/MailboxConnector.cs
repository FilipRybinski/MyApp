using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using QueueMailer.Core.Options;

namespace QueueMailer.Infrastructure.Mailbox.MailboxConnection;

internal class MailboxConnector(IOptions<MailboxOptions> options) : IMailboxConnector
{
    private SmtpClient? _smtpClient;
    private MailboxOptions mailboxOptions = options.Value;


    public async Task<SmtpClient> GetSmtpClient()
    {
        if (_smtpClient is null)
        {
            await InitializeSmtpClient();
        }

        return _smtpClient;
    }

    public async ValueTask DisposeAsync()
    {
        if (_smtpClient is not null)
        {
            await _smtpClient.DisconnectAsync(true);
            _smtpClient.Dispose();
        }
    }

    private async Task InitializeSmtpClient()
    {
        _smtpClient = new SmtpClient();
        try
        {
            await _smtpClient.ConnectAsync(mailboxOptions.Host, mailboxOptions.Port);
            await _smtpClient.AuthenticateAsync(mailboxOptions.Login, mailboxOptions.Password);
        }
        catch
        {
            throw new Exception($"Could not connect to {mailboxOptions.Host}:{mailboxOptions.Port}");
        }
    }
}