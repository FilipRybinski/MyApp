using MediatR;
using QueueMailer.Application.Abstractions;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.SendConfirmationEmail;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.SendConfirmationEmail;

internal sealed class ConfirmationEmailMailboxHandler(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : ICommandHandler<ConfirmationEmail>
{
    public async Task<Result> Handle(ConfirmationEmail request, CancellationToken cancellationToken)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(request.Email));
        return Result.Success();
    }
}