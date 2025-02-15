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
[Route("[controller]/[action]")]
public class IdentityController(
    IQueryHandler<SignUp, IdentityDto> signUpHandler,
    IQueryHandler<SignIn, IdentityDto> signInHandler,
    IAuthorizedHandler authorizedHandler,
    ILogoutHandler logoutHandler)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<IdentityDto>> SignUp(SignUp command)
    {
        return Ok(await signUpHandler.HandleAsync(command));

    }

    [HttpPost]
    public async Task<ActionResult<IdentityDto>> SignIn(SignIn command)
    {
        return Ok(await signInHandler.HandleAsync(command));
    }

    [Authorize]
    [HttpGet]
    public ActionResult<bool> Logout()
    {
        return logoutHandler.Handle();
    }

    [HttpGet]
    public async Task<ActionResult<IdentityDto?>> IsAuthorized()
    {
        return Ok(await authorizedHandler.HandleAsync());
    }
}