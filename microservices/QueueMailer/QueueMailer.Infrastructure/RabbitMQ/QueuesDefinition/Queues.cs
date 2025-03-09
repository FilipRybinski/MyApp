using System.Text.Json;
using QueueMailer.Application.Commands.SendConfirmationEmail;
using QueueMailer.Application.Commands.SendResetPasswordEmail;
using QueueMailer.Application.Dictionary;
using QueueMailer.Core.Abstractions;
using Shared.Core.Abstractions;

namespace QueueMailer.Infrastructure.RabbitMQ.QueuesDefinition;

public class Queues(
    IMailboxHandler<ConfirmationEmail> confirmationEmailHandler,
    IMailboxHandler<ResetPasswordEmail> resetPasswordEmailHandler) : IQueuesDefinition
{
    Dictionary<string, Func<string, Task>> IQueuesDefinition.Definition { get; } =
        new Dictionary<string, Func<string, Task>>
        {
            {
                ChannelDictionary.SignUpQueueMailer, async (string message) =>
                {
                    var response = JsonSerializer.Deserialize<ConfirmationEmail>(message);
                    await confirmationEmailHandler.HandleAsync(response);
                }
            },
            {
                ChannelDictionary.ResetPasswordQueueMailer, async (string message) =>
                {
                    var response = JsonSerializer.Deserialize<ResetPasswordEmail>(message);
                    await resetPasswordEmailHandler.HandleAsync(response);
                }
            }
        };
}