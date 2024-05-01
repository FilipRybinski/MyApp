using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands;
using MyApp.Application.Security;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ICommandHandler<SignUp> _signUpHandler;
    private readonly ICommandHandler<SignIn> _signInHandler;
    
    public UsersController(ICommandHandler<SignUp> signUpHandler,ICommandHandler<SignIn> signInHandler)
    {
        _signUpHandler = signUpHandler;
        _signInHandler = signInHandler;
    }
    
    [HttpPost("SignUp")]
    public async Task<ActionResult> Post(SignUp command)
    {
        command = command with { UserId = Guid.NewGuid() };
        await _signUpHandler.HandleAsync(command);
        return NoContent();
    }
    
    [HttpPost("SignIn")]
    public async Task<ActionResult> Post(SignIn command)
    {
        await _signInHandler.HandleAsync(command);
        return NoContent();
    }
}