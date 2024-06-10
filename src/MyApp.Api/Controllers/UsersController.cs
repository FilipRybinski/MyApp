using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.SignIn;
using MyApp.Application.Commands.SignUp;
using MyApp.Core.DTO;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IEmptyQueryHandler<UserDto> _getMyAccountHandler;
    private readonly ICommandHandler<SignIn> _signInHandler;
    private readonly ICommandHandler<SignUp> _signUpHandler;

    public UsersController(
        ICommandHandler<SignUp> signUpHandler,
        ICommandHandler<SignIn> signInHandler,
        IEmptyQueryHandler<UserDto> getMyAccountHandler
    )
    {
        _signUpHandler = signUpHandler;
        _signInHandler = signInHandler;
        _getMyAccountHandler = getMyAccountHandler;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<bool>> SignUp(SignUp command)
    {
        await _signUpHandler.HandleAsync(command);
        return Ok(true);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<bool>> SignIn(SignIn command)
    {
        await _signInHandler.HandleAsync(command);
        return Ok(true);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<UserDto>> GetMyAccount()
    {
        var result = await _getMyAccountHandler.HandleAsync();
        return Ok(result);
    }
}