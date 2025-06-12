using FeeTracker.Core.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace FeeTracker.Application.Commands.Purpose.Completed;

public class MarkAsCompletedHandler(IFeePurposeRepository feePurposeRepository) : ICommandHandler<MarkAsCompleted>
{
    public async Task<Result> Handle(MarkAsCompleted request, CancellationToken cancellationToken)
    {
        await feePurposeRepository.MarkAsCompleted(request.Id);
        return Result.Success();
    }
}