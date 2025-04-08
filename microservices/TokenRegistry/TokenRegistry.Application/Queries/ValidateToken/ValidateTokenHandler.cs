using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.ValidateToken;

public sealed class ValidateTokenHandler(IValidateTokenRepository validateTokenRepository) : IQueryHandler<ValidateToken, bool>
{
    public async Task<Result<bool>> Handle(ValidateToken request, CancellationToken cancellationToken)
    {
        return  await validateTokenRepository.ValidateToken(request, request.Token, request.TokenType, cancellationToken);
    }
}