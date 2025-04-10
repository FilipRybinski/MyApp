using QueueMailer.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.SendConfirmationEmail;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.SendConfirmationEmail;

public sealed class ConfirmationEmailHandler(IQueueMailerOutBoxRepository queueMailerOutBoxRepository) : ICommandHandler<ConfirmationEmail>
{
    public async Task<Result> Handle(ConfirmationEmail request, CancellationToken cancellationToken)
    {
        await queueMailerOutBoxRepository.HandlePublishAsync<ConfirmationEmail>(request, cancellationToken);
        return Result.Success();
    }
}