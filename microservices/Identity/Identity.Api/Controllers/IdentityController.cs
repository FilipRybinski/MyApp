using System.Threading;
using System.Threading.Tasks;
using Identity.Application.Commands.Activation;
using Identity.Application.Commands.Authorized;
using Identity.Application.Commands.Logout;
using Identity.Application.Commands.Password;
using Identity.Application.Commands.Password.Request;
using Identity.Application.Commands.Password.Submission;
using Identity.Application.Queries.SignIn;
using Identity.Application.Queries.SignUp;
using Identity.Core.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.DTO;
using Shared.Core.Objects;
using Shared.Core.Policies;

namespace Identity.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class IdentityController(
    ISender sender)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Result<IdentityDto>>> SignUp(SignUp command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));

    }

    [HttpPost]
    public async Task<ActionResult<Result<IdentityDto>>> SignIn(SignIn command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    

    [Authorize(Policy = AuthPolicies.External)]
    [HttpGet]
    public async Task<ActionResult<Result>> Logout()
    {
        return Result.MatchResponse(await sender.Send(new LogoutAction()));
    }

    [HttpGet]
    public async Task<ActionResult<Result<IdentityDto?>>> IsAuthorized()
    {
        return Result.MatchResponse(await sender.Send(new IsAuthorized()));
    }

    [HttpPost]
    public async Task<ActionResult<Result>> Activation(ActivationAction command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    } 
    
    [HttpPost]
    public async Task<ActionResult<Result>> ResetPasswordRequest(ResetPasswordRequest command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    } 
    
    [HttpPost]
    public async Task<ActionResult<Result>> ResetPasswordSubmission(PasswordSubmission command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    } 
}