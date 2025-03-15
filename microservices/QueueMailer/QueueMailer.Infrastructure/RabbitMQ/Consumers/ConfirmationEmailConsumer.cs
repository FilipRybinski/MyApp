using MassTransit;
using QueueMailer.Application.Commands.SendConfirmationEmail;
using QueueMailer.Core.Abstractions;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

internal sealed class ConfirmationEmailConsumer(IMailboxHandler<ConfirmationEmail> confirmationEmailHandler) : IConsumer<ConfirmationEmail>
{
    public async Task Consume(ConsumeContext<ConfirmationEmail> context)
    {
        await confirmationEmailHandler.HandleAsync(context.Message, context.CancellationToken);
    }
}