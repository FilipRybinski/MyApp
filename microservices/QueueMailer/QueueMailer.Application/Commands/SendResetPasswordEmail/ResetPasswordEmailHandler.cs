using MediatR;
using QueueMailer.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail;

public sealed class ResetPasswordEmailHandler(IQueueMailerOutBoxRepository queueMailerOutBoxRepository) : ICommandHandler<ResetPasswordEmail,Unit>
{
    public async Task<Result<Unit>> Handle(ResetPasswordEmail request, CancellationToken cancellationToken)
    {
        await queueMailerOutBoxRepository.HandlePublishAsync<ResetPasswordEmail>(request, cancellationToken);

        return Unit.Value;
    }
}