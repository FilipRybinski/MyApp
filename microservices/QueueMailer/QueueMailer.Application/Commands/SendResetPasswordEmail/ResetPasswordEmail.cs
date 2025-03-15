using QueueMailer.Core.Abstractions;
using Shared.Core.Abstractions;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail;

public sealed record ResetPasswordEmail(Guid Id, string Email) : ICommand, IMailbox;