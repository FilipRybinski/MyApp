using MediatR;
using Microsoft.AspNetCore.Mvc;
using TokenRegistry.Application.Queries.LimitedTimeToken;
using TokenRegistry.Application.Queries.MultiTimeToken;
using TokenRegistry.Application.Queries.OneTimeToken;
using TokenRegistry.Application.Queries.ValidateToken;
using TokenRegistry.Core.DTO;

namespace TokenRegistry.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public sealed class TokenRegistryController(
    ISender sender,
    ILogger<TokenRegistryController> logger
    ) : ControllerBase
{

    [HttpPost]
    /*[Authorize(Policy = AuthPolicies.Internal)]*/
    public async Task<ActionResult<TokenDto>> RequestOneTimeToken(OneTimeToken query, CancellationToken cancellationToken)
    {
        var result = await sender.Send(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    /*[Authorize(Policy = AuthPolicies.Internal)]*/
    public async Task<ActionResult<TokenDto>> RequestMultiTimeToken(MultiTimeToken query, CancellationToken cancellationToken)
    {
        var result = await sender.Send(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    /*[Authorize(Policy = AuthPolicies.Internal)]*/
    public async Task<ActionResult<TokenDto>> RequestLimitedTimeToken(LimitedTimeQueryToken query, CancellationToken cancellationToken)
    {
        var result = await sender.Send(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    /*[Authorize]*/
    public async Task<ActionResult<bool>> ValidateToken(ValidateToken query, CancellationToken cancellationToken)
    {
        var result = await sender.Send(query, cancellationToken);
        return Ok(result);
    }
    
}