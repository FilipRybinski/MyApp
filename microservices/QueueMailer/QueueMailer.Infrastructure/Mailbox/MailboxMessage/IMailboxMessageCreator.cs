using MimeKit;

namespace QueueMailer.Infrastructure.Mailbox.MailboxMessage;

internal interface IMailboxMessageCreator
{
    public MimeMessage Create(string recipient);
}