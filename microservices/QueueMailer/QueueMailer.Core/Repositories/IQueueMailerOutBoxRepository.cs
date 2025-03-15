namespace QueueMailer.Core.Repositories;

public interface IQueueMailerOutBoxRepository
{
    Task HandlePublishAsync<T>(T message, CancellationToken cancellationToken) where T : class;
}