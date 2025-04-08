using MassTransit;
using MediatR;
using QueueMailer.Application.Commands.SendResetPasswordEmail;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

internal sealed class ResetPasswordEmailConsumer(ISender sender) : IConsumer<ResetPasswordEmail>
{
    public async Task Consume(ConsumeContext<ResetPasswordEmail> context)
    {
        await sender.Send(context.Message, context.CancellationToken);
    }
}