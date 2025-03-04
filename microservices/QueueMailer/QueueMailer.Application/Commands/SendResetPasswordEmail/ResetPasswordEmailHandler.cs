using Shared.Core.Abstractions;
using Shared.Core.RabbitMq;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail;

public class ResetPasswordEmailHandler(IRabbitMqPublisher publisher) : ICommandHandler<ResetPasswordEmail>
{
    public Task HandleAsync(ResetPasswordEmail command)
    {
        throw new NotImplementedException();
    }
}