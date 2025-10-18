using MimeKit;

namespace QueueMailer.Infrastructure.DAL.Abstractions;

public interface IMailboxMessageCreator
{
    public MimeMessage Create(string recipient,string subject,string body);
}