using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.LimitedTimeToken;

public sealed class LimitedTimeTokenHandler(ILimitedTimeTokenRepository limitedTimeTokenRepository) : IQueryHandler<LimitedTimeQueryToken, TokenDto>
{
    public async Task<Result<TokenDto>> Handle(LimitedTimeQueryToken request, CancellationToken cancellationToken)
    {
        return await limitedTimeTokenRepository.Retrieve(request, cancellationToken);
    }
}