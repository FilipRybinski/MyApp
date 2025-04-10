using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Commands.SendConfirmationEmail;
using Shared.Application.Commands.SendResetPasswordEmail;
using Shared.Core.Policies;

namespace QueueMailer.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Policy = AuthPolicies.Internal)]
public sealed class QueueMailerController(
    ILogger<QueueMailerController> logger,
    ISender sender
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> SendConfirmationEmail(ConfirmationEmail command, CancellationToken cancellationToken)
    {
        await sender.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> SendResetPasswordEmail(ResetPasswordEmail command, CancellationToken cancellationToken)
    {
        await sender.Send(command, cancellationToken);
        return Ok();
    }
}