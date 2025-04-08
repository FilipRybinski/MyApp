using MediatR;
using QueueMailer.Application.Abstractions;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.SendConfirmationEmail;

internal sealed class ConfirmationEmailMailboxHandler(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : ICommandHandler<ConfirmationEmail,Unit>
{
    public async Task<Result<Unit>> Handle(ConfirmationEmail request, CancellationToken cancellationToken)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(request.Email));
        return Unit.Value;
    }
}