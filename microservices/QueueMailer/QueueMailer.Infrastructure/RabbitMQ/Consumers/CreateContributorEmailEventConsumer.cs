using MassTransit;
using QueueMailer.Application.Events;
using QueueMailer.Infrastructure.DAL.Abstractions;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

public class CreateContributorEmailEventConsumer(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : IConsumer<CreateContributorEmailEvent>
{
    private const string Subject = "You've Been Added! Check Out Your New Contribution";

    public async Task Consume(ConsumeContext<CreateContributorEmailEvent> context)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(context.Message.Email, Subject, context.Message.TemplateBody));
    }
}
