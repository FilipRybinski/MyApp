using Identity.Application.Commands.Logout;
using Identity.Application.Queries.SignIn;
using Identity.Application.Queries.SignUp;
using Identity.Core.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Policies;

namespace Identity.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class IdentityController(
    ISender sender)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<IdentityDto>> SignUp(SignUp command, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(command, cancellationToken));

    }

    [HttpPost]
    public async Task<ActionResult<IdentityDto>> SignIn(SignIn command, CancellationToken cancellationToken)
    {
        return Ok(await sender.Send(command, cancellationToken));
    }

    [Authorize(Policy = AuthPolicies.External)]
    [HttpGet]
    public async Task<ActionResult<bool>> Logout()
    {
        return Ok(await sender.Send(new LogoutAction()));
    }

    [HttpGet]
    public async Task<ActionResult<IdentityDto?>> IsAuthorized()
    {
        return Ok(await sender.Send(new LogoutAction()));
    }
}