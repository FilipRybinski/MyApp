using Identity.Application.Handlers.IsAuthorized;
using Identity.Application.Handlers.Logout;
using Identity.Application.Handlers.Token;
using Identity.Application.Queries.SignIn;
using Identity.Application.Queries.SignUp;
using Identity.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Abstractions;
using Shared.Core.Policies;

namespace Identity.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class IdentityController(
    IQueryHandler<SignUp, IdentityDto> signUpHandler,
    IQueryHandler<SignIn, IdentityDto> signInHandler,
    IAuthorizedHandler authorizedHandler,
    ILogoutHandler logoutHandler,
    IRefreshTokenHandler refreshTokenHandler
    )
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<IdentityDto>> SignUp(SignUp command, CancellationToken cancellationToken)
    {
        return Ok(await signUpHandler.HandleAsync(command, cancellationToken));

    }

    [HttpPost]
    public async Task<ActionResult<IdentityDto>> SignIn(SignIn command, CancellationToken cancellationToken)
    {
        return Ok(await signInHandler.HandleAsync(command, cancellationToken));
    }

    [Authorize(Policy = AuthPolicies.External)]
    [HttpGet]
    public ActionResult<bool> Logout(CancellationToken cancellationToken)
    {
        return logoutHandler.Handle(cancellationToken);
    }

    [HttpGet]
    public async Task<ActionResult<IdentityDto?>> IsAuthorized(CancellationToken cancellationToken)
    {
        return Ok(await authorizedHandler.HandleAsync(cancellationToken));
    }
    
    [HttpGet]
    public async Task<ActionResult> RefreshToken(CancellationToken cancellationToken)
    {
        await refreshTokenHandler.HandleAsync(cancellationToken);
        return Ok();
    }
}