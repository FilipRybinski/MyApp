using Shared.Core.Abstractions;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail;

public record ResetPasswordEmail(Guid Id,string Email) : ICommand;