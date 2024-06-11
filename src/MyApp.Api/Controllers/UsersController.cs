using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.SignUp;
using MyApp.Application.Queries.SignIn;
using MyApp.Core.DTO;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IEmptyQueryHandler<UserDto> _getMyAccountHandler;
    private readonly IQueryHandler<SignIn,UserDto> _signInHandler;
    private readonly ICommandHandler<SignUp> _signUpHandler;
    private readonly IEmptyQueryHandler<ActionResultDto> _logOutHandler;

    public UsersController(
        ICommandHandler<SignUp> signUpHandler,
        IQueryHandler<SignIn,UserDto> signInHandler,
        IEmptyQueryHandler<UserDto> getMyAccountHandler,
        IEmptyQueryHandler<ActionResultDto> logOutHandler
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
        var result=await _signInHandler.HandleAsync(command);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("[action]")]
    public async Task<ActionResult<ActionResultDto>> LogOut()
    {
        var result=await _logOutHandler.HandleAsync();
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("[action]")]
    public async Task<ActionResult<UserDto>> GetMyAccount()
    {
        var result = await _getMyAccountHandler.HandleAsync();
        return Ok(result);
    }
}