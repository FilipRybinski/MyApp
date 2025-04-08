using MimeKit;

namespace QueueMailer.Application.Abstractions;

public interface IMailboxPublisher
{
    public Task PublishAsync(MimeMessage message);
}