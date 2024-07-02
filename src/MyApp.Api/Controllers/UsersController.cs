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
    private readonly IQueryHandler<SignIn, UserDto> _signInHandler;
    private readonly ICommandHandler<SignUp> _signUpHandler;

    public UsersController(
        ICommandHandler<SignUp> signUpHandler,
        IQueryHandler<SignIn, UserDto> signInHandler
    )
    {
        _signUpHandler = signUpHandler;
        _signInHandler = signInHandler;
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
}