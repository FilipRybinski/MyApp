using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Commands.Participant.Detach;

public record DetachParticipant(Guid Id, List<Guid> Participants) : ICommand;