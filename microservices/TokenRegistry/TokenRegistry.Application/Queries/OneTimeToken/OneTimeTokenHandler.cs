using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.OneTimeToken;

public sealed class OneTimeTokenHandler(IOneTimeTokenRepository oneTimeTokenRepository) : IQueryHandler<OneTimeToken, TokenDto>
{
    public async Task<Result<TokenDto>> Handle(OneTimeToken request, CancellationToken cancellationToken)
    {
        return await oneTimeTokenRepository.Retrieve(request, cancellationToken);;
    }
}