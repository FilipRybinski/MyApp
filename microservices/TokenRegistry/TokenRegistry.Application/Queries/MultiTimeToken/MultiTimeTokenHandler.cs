using Shared.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Providers;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.MultiTimeToken;

public sealed class MultiTimeTokenHandler(
    IMultiTimeTokenRepository multiTimeTokenRepository,
    ITokenProvider tokenProvider
    ) : IQueryHandler<MultiTimeToken, TokenDto>
{
    public Task<TokenDto> HandleAsync(MultiTimeToken query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}