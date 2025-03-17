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

public sealed class TokenRegistryController(
    IQueryHandler<LimitedTimeQueryToken, TokenDto> limitedTimeTokenHandler,
    IQueryHandler<MultiTimeToken, TokenDto> multiTimeTokenHandler,
    IQueryHandler<OneTimeToken, TokenDto> oneTimeTokenHandler,
    IQueryHandler<ValidateToken, ValidateTokenDto> validateTokenHandler,
    ILogger<TokenRegistryController> logger
    ) : ControllerBase
{

    [HttpPost]
    /*[Authorize(Policy = AuthPolicies.Internal)]*/
    public async Task<ActionResult<TokenDto>> RequestOneTimeToken(OneTimeToken query, CancellationToken cancellationToken)
    {
        var result = await oneTimeTokenHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    /*[Authorize(Policy = AuthPolicies.Internal)]*/
    public async Task<ActionResult<TokenDto>> RequestMultiTimeToken(MultiTimeToken query, CancellationToken cancellationToken)
    {
        var result = await multiTimeTokenHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    /*[Authorize(Policy = AuthPolicies.Internal)]*/
    public async Task<ActionResult<TokenDto>> RequestLimitedTimeToken(LimitedTimeQueryToken query, CancellationToken cancellationToken)
    {
        var result = await limitedTimeTokenHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    /*[Authorize]*/
    public async Task<ActionResult<ValidateTokenDto>> ValidateToken(ValidateToken query, CancellationToken cancellationToken)
    {
        var result = await validateTokenHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
    
}