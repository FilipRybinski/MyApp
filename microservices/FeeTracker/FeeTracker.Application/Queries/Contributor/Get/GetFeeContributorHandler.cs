using AutoMapper;
using FeeTracker.Core.DTO;
using FeeTracker.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Providers.Identity;
using Shared.Core.Objects;

namespace FeeTracker.Application.Queries.Contributor.Get;

public class GetFeeContributorHandler(
    IFeeContributorRepository feeContributorRepository,
    IIdentityProvider identityProvider,
    IMapper mapper
    ) : IQueryHandler<GetFeeContributor,List<FeeContributorDto>>
{
    public async Task<Result<List<FeeContributorDto>>> Handle(GetFeeContributor request, CancellationToken cancellationToken)
    {
        var identityId = identityProvider.ExtractUserIdentityIdentifier();
        var contributors = await feeContributorRepository.GetContributors(identityId);
        return mapper.Map<List<FeeContributorDto>>(contributors);
    }
}