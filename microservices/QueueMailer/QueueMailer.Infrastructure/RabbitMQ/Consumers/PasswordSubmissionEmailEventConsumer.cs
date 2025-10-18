using MassTransit;
using QueueMailer.Application.Events;
using QueueMailer.Infrastructure.DAL.Abstractions;
using Shared.Application.Events;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

public class PasswordSubmissionEmailEventConsumer(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : IConsumer<PasswordSubmissionEmailEvent>
{
    private const string Subject = "All Set! Your Password Has Been Updated";
    public async Task Consume(ConsumeContext<PasswordSubmissionEmailEvent> context)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(context.Message.Email, Subject, context.Message.TemplateBody));
    }
}