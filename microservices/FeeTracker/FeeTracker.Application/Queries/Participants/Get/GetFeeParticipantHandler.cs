using FeeTracker.Core.DTO;
using FeeTracker.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace FeeTracker.Application.Queries.Participants.Get;

public class GetFeeParticipantHandler(IFeeParticipantRepository feeParticipantRepository) : IQueryHandler<GetFeeParticipant,List<FeeParticipantDto>>
{
    public async Task<Result<List<FeeParticipantDto>>> Handle(GetFeeParticipant request, CancellationToken cancellationToken)
    {
        var result = await feeParticipantRepository.GetAllPurposeParticipantsDetails(request.id);

        var mapped = result.Select(e => new FeeParticipantDto()
        {
            Id = e.Id,
            Name = e.Contributor.Name,
            Surname = e.Contributor.Surname,
            Email = e.Contributor.Email,
            HasPaid = e.HasPaid
            
        }).ToList();
        return mapped;
    }
}