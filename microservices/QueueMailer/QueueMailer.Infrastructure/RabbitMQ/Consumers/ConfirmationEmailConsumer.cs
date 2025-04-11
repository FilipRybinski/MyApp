using MassTransit;
using QueueMailer.Application.Abstractions;
using Shared.Application.Commands.SendConfirmationEmail;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

internal sealed class ConfirmationEmailConsumer(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : IConsumer<ConfirmationEmail>
{
    public async Task Consume(ConsumeContext<ConfirmationEmail> context)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(context.Message.Email));
    }
}