using QueueMailer.Application.Connections;
using Shared.Core.Abstractions;

namespace QueueMailer.Application.Commands.SendConfirmationEmail;

public class ConfirmationEmailHandler(IRabbitMqPublisher publisher) : ICommandHandler<ConfirmationEmail>
{
    public async Task HandleAsync(ConfirmationEmail command)
    {
        await publisher.PublishAsync<ConfirmationEmail>("SignUpQueueMailer",command);
    }
}