using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Commands.Participant.Paid;

public record MarkAsPaid(Guid Id) : ICommand;