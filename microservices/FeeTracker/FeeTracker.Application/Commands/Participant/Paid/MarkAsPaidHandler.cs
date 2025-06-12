using FeeTracker.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace FeeTracker.Application.Commands.Participant.Paid;

public class MarkAsPaidHandler(IFeeParticipantRepository feeParticipantRepository): ICommandHandler<MarkAsPaid>
{
    public async Task<Result> Handle(MarkAsPaid request, CancellationToken cancellationToken)
    {
        await feeParticipantRepository.MarkAsPaid(request.Id);
        return Result.Success();
    }
}