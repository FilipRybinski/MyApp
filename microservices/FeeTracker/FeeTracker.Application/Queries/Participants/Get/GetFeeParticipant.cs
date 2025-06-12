using FeeTracker.Core.DTO;
using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Queries.Participants.Get;

public record GetFeeParticipant(Guid id) : IQuery<List<FeeParticipantDto>>;