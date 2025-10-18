using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.MultiTimeToken;

public sealed class MultiTimeTokenHandler(IMultiTimeTokenRepository multiTimeTokenRepository) : IQueryHandler<MultiTimeToken, TokenDto>
{
    public async Task<Result<TokenDto>> Handle(MultiTimeToken request, CancellationToken cancellationToken)
    {
        return await multiTimeTokenRepository.Retrieve(request, cancellationToken);;
    }
}