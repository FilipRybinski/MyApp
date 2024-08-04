using Common.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Handlers.IsAuthorized;
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

    public UsersController(
        IQueryHandler<SignUp,UserDto> signUpHandler,
        IQueryHandler<SignIn, UserDto> signInHandler,
        IAuthorizedHandler authorizedHandler
    )
    {
        _signUpHandler = signUpHandler;
        _signInHandler = signInHandler;
        _authorizedHandler = authorizedHandler;
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

    [HttpGet("[action]")]
    public async Task<ActionResult<UserDto?>> IsAuthorized()
    {
        return Ok(await _authorizedHandler.HandleAsync());
    }
}