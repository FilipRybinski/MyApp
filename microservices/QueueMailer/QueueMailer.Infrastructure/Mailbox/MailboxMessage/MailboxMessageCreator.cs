using Microsoft.Extensions.Options;
using MimeKit;
using QueueMailer.Core.Configuration;

namespace QueueMailer.Infrastructure.Mailbox.MailboxMessage;

internal class MailboxMessageCreator(IOptions<MailboxConfiguration> options) : IMailboxMessageCreator
{
    private MailboxConfiguration mailboxConfiguration = options.Value;

    public MimeMessage Create(string recipient)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("[@support] MyAppZone", mailboxConfiguration.Login));
        message.To.Add(new MailboxAddress(String.Empty, recipient));
        message.Subject = "Test Mailbox";
        return message;
    }
}