using MassTransit;
using QueueMailer.Core.Repositories;
using QueueMailer.Infrastructure.DAL.Context;

namespace QueueMailer.Infrastructure.DAL.Repositories;

internal sealed class QueueMailerOutBoxRepository(
    QueueMailerDbContext dbContext,
    IPublishEndpoint publishEndpoint) : IQueueMailerOutBoxRepository
{

    public async Task HandlePublishAsync<T>(T message, CancellationToken cancellationToken) where T : class
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        await publishEndpoint.Publish(message, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}