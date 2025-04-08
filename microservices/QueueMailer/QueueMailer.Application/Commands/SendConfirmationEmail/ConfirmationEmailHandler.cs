using MediatR;
using QueueMailer.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.SendConfirmationEmail;

public sealed class ConfirmationEmailHandler(IQueueMailerOutBoxRepository queueMailerOutBoxRepository) : ICommandHandler<ConfirmationEmail,Unit>
{
    public async Task<Result<Unit>> Handle(ConfirmationEmail request, CancellationToken cancellationToken)
    {
        await queueMailerOutBoxRepository.HandlePublishAsync<ConfirmationEmail>(request, cancellationToken);
        return Unit.Value;
    }
}