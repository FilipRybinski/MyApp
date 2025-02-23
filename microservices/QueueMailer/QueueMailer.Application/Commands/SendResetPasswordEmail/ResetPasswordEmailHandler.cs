using QueueMailer.Application.Connections;
using Shared.Core.Abstractions;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail;

public class ResetPasswordEmailHandler(IRabbitMqPublisher publisher) : ICommandHandler<ResetPasswordEmail>
{
    public Task HandleAsync(ResetPasswordEmail command)
    {
        throw new NotImplementedException();
    }
}