using MassTransit;
using QueueMailer.Application.Events;
using QueueMailer.Infrastructure.DAL.Abstractions;
using Shared.Application.Events;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

internal sealed class ActivationEmailEventConsumer(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : IConsumer<ActivationEmailEvent>
{
    private const string Subject = "Account Activated – Welcome Aboard!";
    public async Task Consume(ConsumeContext<ActivationEmailEvent> context)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(context.Message.Email, Subject, context.Message.TemplateBody));
    }
}