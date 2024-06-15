using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.SignUp;
using MyApp.Application.Handlers.GetMyAccount;
using MyApp.Application.Queries.LogOut;
using MyApp.Application.Queries.SignIn;
using MyApp.Core.DTO;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IGetMyAccountHandler _getMyAccountHandler;
    private readonly ILogOut _logOutHandler;
    private readonly IQueryHandler<SignIn, UserDto> _signInHandler;
    private readonly ICommandHandler<SignUp> _signUpHandler;

    public UsersController(
        ICommandHandler<SignUp> signUpHandler,
        IQueryHandler<SignIn, UserDto> signInHandler,
        IGetMyAccountHandler getMyAccountHandler,
        ILogOut logOutHandler
    )
    {
        _signUpHandler = signUpHandler;
        _signInHandler = signInHandler;
        _getMyAccountHandler = getMyAccountHandler;
        _logOutHandler = logOutHandler;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<bool>> SignUp(SignUp command)
    {
        await _signUpHandler.HandleAsync(command);
        return Ok(true);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<UserDto>> SignIn(SignIn command)
    {
        var result = await _signInHandler.HandleAsync(command);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("[action]")]
    public async Task<ActionResult> LogOut()
    {
        await _logOutHandler.HandleAsync();
        return Ok();
    }

    [Authorize]
    [HttpGet("[action]")]
    public async Task<ActionResult<UserDto>> GetMyAccount()
    {
        var result = await _getMyAccountHandler.HandleAsync();
        return Ok(result);
    }
}