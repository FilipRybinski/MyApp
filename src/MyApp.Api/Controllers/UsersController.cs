using Common.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Handlers.IsAuthorized;
using MyApp.Application.Handlers.Logout;
using MyApp.Application.Queries.SignIn;
using MyApp.Application.Queries.SignUp;
using MyApp.Core.DTO;
using MyApp.Core.Entities;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IQueryHandler<SignIn, UserDto> _signInHandler;
    private readonly IQueryHandler<SignUp,UserDto> _signUpHandler;
    private readonly IAuthorizedHandler _authorizedHandler;
    private readonly ILogoutHandler _logoutHandler;

    public UsersController(
        IQueryHandler<SignUp,UserDto> signUpHandler,
        IQueryHandler<SignIn, UserDto> signInHandler,
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
    public async Task<ActionResult<UserDto>> SignUp(SignUp command)
    {
        return Ok(await _signUpHandler.HandleAsync(command));

    }

    [HttpPost("[action]")]
    public async Task<ActionResult<UserDto>> SignIn(SignIn command)
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
    public async Task<ActionResult<UserDto?>> IsAuthorized()
    {
        return Ok(await _authorizedHandler.HandleAsync());
    }
}