using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace FeeTracker.Application.Commands.Purpose.Edit;

public class EditFeePurposeHandler : ICommandHandler<EditFeePurpose>
{
    public Task<Result> Handle(EditFeePurpose request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}