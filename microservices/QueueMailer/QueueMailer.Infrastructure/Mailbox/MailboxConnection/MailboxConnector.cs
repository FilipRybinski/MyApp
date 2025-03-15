using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using QueueMailer.Core.Configuration;

namespace QueueMailer.Infrastructure.Mailbox.MailboxConnection;

internal sealed class MailboxConnector(IOptions<MailboxConfiguration> options) : IMailboxConnector
{
    private SmtpClient? _smtpClient;
    private MailboxConfiguration mailboxConfiguration = options.Value;


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
            await _smtpClient.ConnectAsync(mailboxConfiguration.Host, mailboxConfiguration.Port);
            await _smtpClient.AuthenticateAsync(mailboxConfiguration.Login, mailboxConfiguration.Password);
        }
        catch
        {
            throw new Exception($"Could not connect to {mailboxConfiguration.Host}:{mailboxConfiguration.Port}");
        }
    }
}