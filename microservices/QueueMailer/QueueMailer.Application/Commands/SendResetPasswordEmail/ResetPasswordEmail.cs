using MediatR;
using Shared.Application.Abstractions.CQRS;

namespace QueueMailer.Application.Commands.SendResetPasswordEmail;

public sealed record ResetPasswordEmail(Guid Id, string Email) : ICommand<Unit>;