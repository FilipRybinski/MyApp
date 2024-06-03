using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands;
using MyApp.Application.Commands.SignIn;
using MyApp.Application.Commands.SignUp;
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
    
    [HttpPost("[action]")]
    public async Task<ActionResult> SignUp(SignUp command)
    {
        await _signUpHandler.HandleAsync(command);
        return Ok();
    }
    [HttpPost("[action]")]
    public async Task<ActionResult> SignIn(SignIn command)
    {
        await _signInHandler.HandleAsync(command);
        return Ok();
    }
}