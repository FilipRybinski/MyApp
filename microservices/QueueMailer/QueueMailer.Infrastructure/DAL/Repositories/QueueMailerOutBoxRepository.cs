using MassTransit;
using QueueMailer.Application.Repositories;
using QueueMailer.Infrastructure.DAL.Context;
using Shared.Core.Objects;

namespace QueueMailer.Infrastructure.DAL.Repositories;

internal sealed class QueueMailerOutBoxRepository(
    QueueMailerDbContext dbContext,
    IPublishEndpoint publishEndpoint) : IQueueMailerOutBoxRepository
{

    public async Task<Result> HandlePublishAsync<T>(T message, CancellationToken cancellationToken) where T : class
    {
        try
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            await publishEndpoint.Publish(message, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return Result.Failure(Error.InternalServerError("Error while publishing"));
        }
       
        return Result.Success();
    }
}