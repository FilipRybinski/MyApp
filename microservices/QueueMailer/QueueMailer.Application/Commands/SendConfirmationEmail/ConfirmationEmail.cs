using QueueMailer.Core.Abstractions;
using Shared.Core.Abstractions;

namespace QueueMailer.Application.Commands.SendConfirmationEmail;

public sealed record ConfirmationEmail(Guid Id, string Email) : ICommand, IMailbox;