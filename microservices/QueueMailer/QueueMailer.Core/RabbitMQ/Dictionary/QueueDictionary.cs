using System.Text.Json;
using QueueMailer.Application.Commands.SendConfirmationEmail;
using QueueMailer.Application.Dictionary;

namespace QueueMailer.Core.RabbitMQ.Dictionary;

public static class QueueDictionary
{
    public const string Host = "RabbitMQ";
    public static readonly Dictionary<string, Func<string, Task>> Queues = new()
    {
        {
            ChannelDictionary.SignUpQueueMailer, async (string message) =>
            {
                var response = JsonSerializer.Deserialize<ConfirmationEmail>(message);
                await Task.CompletedTask;
            }
        },
        {
            ChannelDictionary.ResetPasswordQueueMailer, async (string message) =>
            {
                var response = JsonSerializer.Deserialize<ConfirmationEmail>(message);
                await Task.CompletedTask;
            }
        }
    };
}