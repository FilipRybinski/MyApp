using QueueMailer.Core.Repositories;
using Shared.Core.Abstractions;

namespace QueueMailer.Application.Commands.SendConfirmationEmail;

public sealed class ConfirmationEmailHandler(IQueueMailerOutBoxRepository queueMailerOutBoxRepository) : ICommandHandler<ConfirmationEmail>
{
    public async Task HandleAsync(ConfirmationEmail command, CancellationToken cancellationToken) =>  await queueMailerOutBoxRepository.HandlePublishAsync<ConfirmationEmail>(command, cancellationToken);
}