using FeeTracker.Core.Repositories;
using FeeTracker.Domain.Purpose;
using FeeTracker.Domain.PurposeOwner;
using Shared.Application.Abstractions.CQRS;
using Shared.Application.Providers.Identity;
using Shared.Core.Objects;

namespace FeeTracker.Application.Commands.Purpose.Add;

public class AddFeePurposeHandler(
    IFeePurposeOwnerRepository feePurposeOwnerRepository,
    IFeePurposeRepository feePurposeRepository,
    IIdentityProvider identityProvider
    ) : ICommandHandler<AddFeePurpose>
{
    public async Task<Result> Handle(AddFeePurpose request, CancellationToken cancellationToken)
    {
        var identityId = identityProvider.ExtractUserIdentityIdentifier();
        
        if (!feePurposeOwnerRepository.IsFeePurposeOwnerAlreadyExist(identityId))
        {
            var owner = new FeePurposeOwner(identityId);
            await feePurposeOwnerRepository.CreateFeePurposeOwner(owner);
        }
        
        var purpose = new FeePurpose(
            request.Title,
            request.StartDate,
            request.EndDate,
            request.Amount,
            identityId
        );
        await feePurposeRepository.CreateFeePurpose(purpose);

        return Result.Success();
    }
}