using Microsoft.Extensions.Options;
using MimeKit;
using QueueMailer.Core.Options;

namespace QueueMailer.Infrastructure.Mailbox.MailboxMessage;

internal class MailboxMessageCreator(IOptions<MailboxOptions> options) : IMailboxMessageCreator
{
    private MailboxOptions mailboxOptions = options.Value;

    public MimeMessage Create(string recipient)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("[@support] MyAppZone", mailboxOptions.Login));
        message.To.Add(new MailboxAddress(String.Empty, recipient));
        message.Subject = "Test Mailbox";
        return message;
    }
}