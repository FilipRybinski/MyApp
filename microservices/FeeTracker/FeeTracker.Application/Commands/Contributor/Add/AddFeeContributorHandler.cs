using AutoMapper;
using FeeTracker.Core.Repositories;
using FeeTracker.Domain.Contributor;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Providers.Identity;
using Shared.Core.DTO;
using Shared.Core.Objects;

namespace FeeTracker.Application.Commands.Contributor.Add;

public class AddFeeContributorHandler(
    IFeeContributorRepository feeContributorRepository,
    IIdentityProvider identityProvider,
    IMapper mapper
    ) : ICommandHandler<AddFeeContributor>
{
    public async Task<Result> Handle(AddFeeContributor request, CancellationToken cancellationToken)
    {
        var contributor = new FeeContributor(request.Name, request.Surname, request.Email);
        var identity = mapper.Map<IdentityDto>(contributor);
        contributor.Raise(new FeeContributorCreatedDomainEvent(identity));
        await feeContributorRepository.CreateContributor(contributor);
        return Result.Success();
    }
}