using FeeTracker.Core.Repositories;
using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Commands.Participant.Attach;

public record AttachParticipant(Guid Id, List<Guid> Participants) : ICommand;