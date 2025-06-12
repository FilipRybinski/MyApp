using AutoMapper;
using FeeTracker.Core.DTO;
using FeeTracker.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Providers.Identity;
using Shared.Core.Objects;

namespace FeeTracker.Application.Queries.Purpose.Get;

public class GetFeePurposeHandler(
    IFeePurposeRepository feePurposeRepository,
    IIdentityProvider identityProvider,
    IMapper mapper
    ) : IQueryHandler<GetFeePurpose,List<FeePurposeDto>>
{
    public async Task<Result<List<FeePurposeDto>>> Handle(GetFeePurpose request, CancellationToken cancellationToken)
    {
        var identityId = identityProvider.ExtractUserIdentityIdentifier();
        var purposes = await feePurposeRepository.GetFeePurposes(identityId);
        var result = mapper.Map<List<FeePurposeDto>>(purposes);

        foreach (var r in result)
        {
            r.Participants = await feePurposeRepository.GetListOfParticipats(r.Id);
        }

        return result;

    }
}