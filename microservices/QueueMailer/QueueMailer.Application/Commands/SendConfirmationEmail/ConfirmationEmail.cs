using MediatR;
using Shared.Application.Abstractions.CQRS;


namespace QueueMailer.Application.Commands.SendConfirmationEmail;

public sealed record ConfirmationEmail(Guid Id, string Email) : ICommand<Unit>;