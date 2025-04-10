using MediatR;
using QueueMailer.Application.Abstractions;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.SendResetPasswordEmail;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail
{
    internal sealed class ResetPasswordEmailMailboxHandler(
        IMailboxMessageCreator mailboxMessageCreator,
        IMailboxPublisher mailboxPublisher) : ICommandHandler<ResetPasswordEmail>
    {
        public async Task<Result> Handle(ResetPasswordEmail request, CancellationToken cancellationToken)
        {
            await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(request.Email));
            return Result.Success();
        }
    }
}