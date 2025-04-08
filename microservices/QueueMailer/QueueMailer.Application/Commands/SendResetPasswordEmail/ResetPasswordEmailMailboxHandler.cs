using MediatR;
using QueueMailer.Application.Abstractions;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail
{
    internal sealed class ResetPasswordEmailMailboxHandler(
        IMailboxMessageCreator mailboxMessageCreator,
        IMailboxPublisher mailboxPublisher) : ICommandHandler<ResetPasswordEmail,Unit>
    {
        public async Task<Result<Unit>> Handle(ResetPasswordEmail request, CancellationToken cancellationToken)
        {
            await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(request.Email));
            return Unit.Value;
        }
    }
}