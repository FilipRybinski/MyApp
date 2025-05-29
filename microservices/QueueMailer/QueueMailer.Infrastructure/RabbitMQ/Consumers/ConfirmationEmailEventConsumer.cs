using MassTransit;
using QueueMailer.Application.Events;
using QueueMailer.Infrastructure.DAL.Abstractions;
using QueueMailer.Infrastructure.Template;
using QueueMailer.Infrastructure.Template.Reader;
using RequestClient.Handler;
using Shared.Application.Commands.Token;
using Shared.Application.Events;
using Shared.Application.Routes;
using Shared.Core.DTO;
using Shared.Core.Enums;
using Shared.Core.Objects;

namespace QueueMailer.Infrastructure.RabbitMQ.Consumers;

internal sealed class ConfirmationEmailEventConsumer(
    IMailboxMessageCreator mailboxMessageCreator,
    IMailboxPublisher mailboxPublisher) : IConsumer<ConfirmationEmailEvent>
{
    private const string Subject = "Ready to Join Us? Activate Your Account!";
    public async Task Consume(ConsumeContext<ConfirmationEmailEvent> context)
    {
        await mailboxPublisher.PublishAsync(mailboxMessageCreator.Create(context.Message.Email, Subject, context.Message.TemplateBody));
    }
}