using FeeTracker.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace FeeTracker.Application.Commands.Participant.Detach;

public class DetachParticipantHandler(IFeeParticipantRepository feeParticipantRepository) : ICommandHandler<DetachParticipant>
{
    public Task<Result> Handle(DetachParticipant request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}