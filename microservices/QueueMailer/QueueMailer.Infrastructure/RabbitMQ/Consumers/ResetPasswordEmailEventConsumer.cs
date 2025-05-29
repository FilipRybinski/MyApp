using MassTransit;
using QueueMailer.Application.Events;
using QueueMailer.Infrastructure.DAL.Abstractions;
using Shared.Application.Events;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

internal sealed class ResetPasswordEmailEventConsumer(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : IConsumer<ResetPasswordEmailEvent>
{
    private const string Subject = "Forgot Your Password? No Worries!";
    public async Task Consume(ConsumeContext<ResetPasswordEmailEvent> context)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(context.Message.Email, Subject, context.Message.TemplateBody));
    }
}