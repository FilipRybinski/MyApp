using MassTransit;
using QueueMailer.Application.Abstractions;
using Shared.Application.Commands.SendResetPasswordEmail;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

internal sealed class ResetPasswordEmailConsumer(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : IConsumer<ResetPasswordEmail>
{
    public async Task Consume(ConsumeContext<ResetPasswordEmail> context)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(context.Message.Email));
    }
}