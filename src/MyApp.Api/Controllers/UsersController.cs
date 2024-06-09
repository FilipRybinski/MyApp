using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.SignIn;
using MyApp.Application.Commands.SignUp;
using MyApp.Application.DTO;
using MyApp.Application.Queries.GetMyAccount;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IQueryHandler<GetMyAccount, UserDto> _getMyAccountHandler;
    private readonly ICommandHandler<SignIn> _signInHandler;
    private readonly ICommandHandler<SignUp> _signUpHandler;

    public UsersController(
        ICommandHandler<SignUp> signUpHandler,
        ICommandHandler<SignIn> signInHandler,
        IQueryHandler<GetMyAccount, UserDto> getMyAccountHandler
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
    public async Task<ActionResult<UserDto>> GetMyAccount(GetMyAccount query)
    {
        var result = await _getMyAccountHandler.HandleAsync(query);
        return Ok(result);
    }
}