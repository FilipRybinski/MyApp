using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Providers;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.LimitedTimeToken;

public sealed class LimitedTimeTokenHandler(
    ILimitedTimeTokenRepository limitedTimeTokenRepository,
    ITokenProvider tokenProvider
    ) : IQueryHandler<LimitedTimeToken, TokenDto>
{
    public Task<TokenDto> HandleAsync(LimitedTimeToken query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}