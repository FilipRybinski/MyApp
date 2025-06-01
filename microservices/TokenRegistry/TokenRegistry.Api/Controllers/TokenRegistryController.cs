using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Commands.Token;
using Shared.Core.DTO;
using Shared.Core.Objects;
using Shared.Core.Policies;
using TokenRegistry.Application.Queries.LimitedTimeToken;
using TokenRegistry.Application.Queries.MultiTimeToken;
using TokenRegistry.Application.Queries.OneTimeToken;

namespace TokenRegistry.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Policy = AuthPolicies.Internal)]
public sealed class TokenRegistryController(
    ISender sender,
    ILogger<TokenRegistryController> logger
    ) : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult<Result<TokenDto>>> RequestOneTimeToken(OneTimeToken query, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(query, cancellationToken));
    }
    
    [HttpPost]
    public async Task<ActionResult<Result<TokenDto>>> RequestMultiTimeToken(MultiTimeToken query, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(query, cancellationToken));
    }
    
    [HttpPost]
    public async Task<ActionResult<Result<TokenDto>>> RequestLimitedTimeToken(LimitedTimeQueryToken query, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(query, cancellationToken));
    }
    
    [HttpPost]
    public async Task<ActionResult<Result<TokenValidationDto>>> ValidateToken(ValidateToken query, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(query, cancellationToken));
    }
    
}