using MassTransit;
using QueueMailer.Application.Commands.SendResetPasswordEmail;
using QueueMailer.Core.Abstractions;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

internal sealed class ResetPasswordEmailConsumer(IMailboxHandler<ResetPasswordEmail> resetPasswordEmailHandler) : IConsumer<ResetPasswordEmail>
{
    public async Task Consume(ConsumeContext<ResetPasswordEmail> context)
    {
        await resetPasswordEmailHandler.HandleAsync(context.Message, context.CancellationToken);
    }
}