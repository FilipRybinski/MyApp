using FeeTracker.Core.Repositories;
using FeeTracker.Domain.Participant;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace FeeTracker.Application.Commands.Participant.Attach;

public class AttachParticipantHandler(IFeeParticipantRepository feeParticipantRepository) : ICommandHandler<AttachParticipant>
{
    public async Task<Result> Handle(AttachParticipant request, CancellationToken cancellationToken)
    {
        var participants = request.Participants
            .Select(id => new FeeParticipant(request.Id, id))
            .ToList();
        await feeParticipantRepository.AttachParticipant(participants);
        return Result.Success();
    }
}