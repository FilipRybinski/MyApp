using MassTransit;
using MediatR;
using Shared.Application.Commands.SendConfirmationEmail;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

internal sealed class ConfirmationEmailConsumer(ISender sender) : IConsumer<ConfirmationEmail>
{
    public async Task Consume(ConsumeContext<ConfirmationEmail> context)
    {
        await sender.Send(context.Message, context.CancellationToken);
    }
}