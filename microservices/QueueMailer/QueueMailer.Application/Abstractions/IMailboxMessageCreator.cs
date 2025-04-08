using MimeKit;

namespace QueueMailer.Application.Abstractions;

public interface IMailboxMessageCreator
{
    public MimeMessage Create(string recipient);
}