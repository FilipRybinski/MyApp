using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Abstractions;
using Shared.Core.Policies;
using TokenRegistry.Application.Queries.LimitedTimeToken;
using TokenRegistry.Application.Queries.MultiTimeToken;
using TokenRegistry.Application.Queries.OneTimeToken;
using TokenRegistry.Application.Queries.ValidateToken;
using TokenRegistry.Core.DTO;

namespace TokenRegistry.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Policy = AuthPolicies.Internal)]
public sealed class TokenRegistryController(
    IQueryHandler<LimitedTimeToken, TokenDto> limitedTimeTokenHandler,
    IQueryHandler<MultiTimeToken, TokenDto> multiTimeTokenHandler,
    IQueryHandler<OneTimeToken, TokenDto> oneTimeTokenHandler,
    IQueryHandler<ValidateToken, bool> validateTokenHandler,
    ILogger<TokenRegistryController> logger
    ) : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult<TokenDto>> RequestOneTimeToken(OneTimeToken query, CancellationToken cancellationToken)
    {
        var result = await oneTimeTokenHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<TokenDto>> RequestMultiTimeToken(MultiTimeToken query, CancellationToken cancellationToken)
    {
        var result = await multiTimeTokenHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<TokenDto>> RequestLimitedTimeToken(LimitedTimeToken query, CancellationToken cancellationToken)
    {
        var result = await limitedTimeTokenHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<bool>> ValidateToken(ValidateToken query, CancellationToken cancellationToken)
    {
        var result = await validateTokenHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
    
}