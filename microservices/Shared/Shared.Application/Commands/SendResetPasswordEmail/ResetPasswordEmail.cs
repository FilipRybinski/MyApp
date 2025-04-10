using Shared.Application.Abstractions.CQRS;

namespace Shared.Application.Commands.SendResetPasswordEmail;

public sealed record ResetPasswordEmail(Guid Id, string Email) : ICommand;