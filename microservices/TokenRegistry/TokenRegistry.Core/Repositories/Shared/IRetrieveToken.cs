using Shared.Application.Commands.Token;
using Shared.Core.DTO;

namespace TokenRegistry.Core.Repositories.Shared;

public interface IRetrieveToken
{
    public Task<TokenDto> Retrieve(TokenQuery query, CancellationToken cancellationToken);
}