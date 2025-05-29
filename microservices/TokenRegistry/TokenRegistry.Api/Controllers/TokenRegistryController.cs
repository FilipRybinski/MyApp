using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Commands.Token;
using Shared.Core.DTO;
using Shared.Core.Objects;
using TokenRegistry.Application.Queries.LimitedTimeToken;
using TokenRegistry.Application.Queries.MultiTimeToken;
using TokenRegistry.Application.Queries.OneTimeToken;

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
    public async Task<ActionResult<Result<TokenDto>>> RequestOneTimeToken(OneTimeToken query, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(query, cancellationToken));
    }
    
    [HttpPost]
    /*[Authorize(Policy = AuthPolicies.Internal)]*/
    public async Task<ActionResult<Result<TokenDto>>> RequestMultiTimeToken(MultiTimeToken query, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(query, cancellationToken));
    }
    
    [HttpPost]
    /*[Authorize(Policy = AuthPolicies.Internal)]*/
    public async Task<ActionResult<Result<TokenDto>>> RequestLimitedTimeToken(LimitedTimeQueryToken query, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(query, cancellationToken));
    }
    
    [HttpPost]
    /*[Authorize]*/
    public async Task<ActionResult<Result<TokenValidationDto>>> ValidateToken(ValidateToken query, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(query, cancellationToken));
    }
    
}