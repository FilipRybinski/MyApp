using Shared.Application.Abstractions.CQRS;

namespace Shared.Application.Commands.SendConfirmationEmail;

public sealed record ConfirmationEmail(Guid Id, string Email) : ICommand;