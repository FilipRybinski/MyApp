using FeeTracker.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace FeeTracker.Application.Commands.Purpose.Delete;

public class DeleteFeePurposeHandler( IFeePurposeRepository feePurposeRepository) : ICommandHandler<DeleteFeePurpose>
{
    public async Task<Result> Handle(DeleteFeePurpose request, CancellationToken cancellationToken)
    {
        await feePurposeRepository.DeleteFeePurpose(request.Id);
        return Result.Success();
    }
}