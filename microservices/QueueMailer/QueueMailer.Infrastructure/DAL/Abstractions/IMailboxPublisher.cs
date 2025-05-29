using MimeKit;

namespace QueueMailer.Infrastructure.DAL.Abstractions;

public interface IMailboxPublisher
{
    public Task PublishAsync(MimeMessage message);
}