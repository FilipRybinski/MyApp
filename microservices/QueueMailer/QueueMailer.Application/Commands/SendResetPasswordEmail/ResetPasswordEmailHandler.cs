using MediatR;
using QueueMailer.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.SendResetPasswordEmail;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail;

public sealed class ResetPasswordEmailHandler(IQueueMailerOutBoxRepository queueMailerOutBoxRepository) : ICommandHandler<ResetPasswordEmail>
{
    public async Task<Result> Handle(ResetPasswordEmail request, CancellationToken cancellationToken)
    {
        await queueMailerOutBoxRepository.HandlePublishAsync<ResetPasswordEmail>(request, cancellationToken);

        return Result.Success();
    }
}