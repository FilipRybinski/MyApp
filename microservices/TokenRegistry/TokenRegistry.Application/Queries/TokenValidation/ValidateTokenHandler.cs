using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.Token;
using Shared.Core.DTO;
using Shared.Core.Objects;
using TokenRegistry.Core.Repositories;

namespace TokenRegistry.Application.Queries.TokenValidation;

public sealed class ValidateTokenHandler(IValidateTokenRepository validateTokenRepository) : IQueryHandler<ValidateToken, TokenValidationDto>
{
    public async Task<Result<TokenValidationDto>> Handle(ValidateToken request, CancellationToken cancellationToken)
    {
        var isValid = await validateTokenRepository.ValidateToken(request, request.Token, request.TokenType, cancellationToken);
        return new TokenValidationDto
        {
            IsValid = isValid
        };
    }
}