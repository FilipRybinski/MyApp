using QueueMailer.Core.Repositories;
using Shared.Core.Abstractions;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail;

public sealed class ResetPasswordEmailHandler(IQueueMailerOutBoxRepository queueMailerOutBoxRepository) : ICommandHandler<ResetPasswordEmail>
{
    public async Task HandleAsync(ResetPasswordEmail command, CancellationToken cancellationToken) => await queueMailerOutBoxRepository.HandlePublishAsync<ResetPasswordEmail>(command, cancellationToken);
}