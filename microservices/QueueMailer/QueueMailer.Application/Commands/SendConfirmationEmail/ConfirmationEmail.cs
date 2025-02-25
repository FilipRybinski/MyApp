using QueueMailer.Core.Abstractions;
using Shared.Core.Abstractions;

namespace QueueMailer.Application.Commands.SendConfirmationEmail;

public record ConfirmationEmail(Guid Id, string Email) : ICommand, IMailbox;