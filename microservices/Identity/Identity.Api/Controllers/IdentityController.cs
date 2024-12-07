using Identity.Application.Handlers.IsAuthorized;
using Identity.Application.Handlers.Logout;
using Identity.Application.Queries.SignIn;
using Identity.Application.Queries.SignUp;
using Identity.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Abstractions;

namespace Identity.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IQueryHandler<SignIn, IdentityDto> _signInHandler;
    private readonly IQueryHandler<SignUp,IdentityDto> _signUpHandler;
    private readonly IAuthorizedHandler _authorizedHandler;
    private readonly ILogoutHandler _logoutHandler;

    public IdentityController(
        IQueryHandler<SignUp,IdentityDto> signUpHandler,
        IQueryHandler<SignIn, IdentityDto> signInHandler,
        IAuthorizedHandler authorizedHandler,
        ILogoutHandler logoutHandler
    )
    {
        _signUpHandler = signUpHandler;
        _signInHandler = signInHandler;
        _authorizedHandler = authorizedHandler;
        _logoutHandler = logoutHandler;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<IdentityDto>> SignUp(SignUp command)
    {
        return Ok(await _signUpHandler.HandleAsync(command));

    }

    [HttpPost("[action]")]
    public async Task<ActionResult<IdentityDto>> SignIn(SignIn command)
    {
        return Ok(await _signInHandler.HandleAsync(command));
    }

    [Authorize]
    [HttpGet("[action]")]
    public ActionResult<bool> Logout()
    {
        return _logoutHandler.Handle();
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IdentityDto?>> IsAuthorized()
    {
        return Ok(await _authorizedHandler.HandleAsync());
    }
}