using Shared.Core.Objects;

namespace QueueMailer.Application.Repositories;

public interface IQueueMailerOutBoxRepository
{
    Task<Result> HandlePublishAsync<T>(T message, CancellationToken cancellationToken) where T : class;
}