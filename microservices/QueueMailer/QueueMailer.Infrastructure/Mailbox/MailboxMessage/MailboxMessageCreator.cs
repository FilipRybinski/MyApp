using Microsoft.Extensions.Options;
using MimeKit;
using QueueMailer.Core.Configuration;
using QueueMailer.Infrastructure.DAL.Abstractions;

namespace QueueMailer.Infrastructure.Mailbox.MailboxMessage;

internal sealed class MailboxMessageCreator(IOptions<MailboxConfiguration> options) : IMailboxMessageCreator
{
    private MailboxConfiguration mailboxConfiguration = options.Value;

    public MimeMessage Create(string recipient,string subject,string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("[@support] MyAppZone", mailboxConfiguration.Login));
        message.To.Add(new MailboxAddress(String.Empty, recipient));
        message.Subject = subject;
        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = body
        };
        message.Body = bodyBuilder.ToMessageBody();
        
        return message;
    }
}