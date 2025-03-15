using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueueMailer.Application.Commands.SendConfirmationEmail;
using QueueMailer.Application.Commands.SendResetPasswordEmail;
using Shared.Core.Abstractions;
using Shared.Core.Policies;

namespace QueueMailer.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Policy = AuthPolicies.Internal)]
public sealed class QueueMailerController(
    ILogger<QueueMailerController> logger,
    ICommandHandler<ConfirmationEmail> confirmationEmailHandler,
    ICommandHandler<ResetPasswordEmail> resetPasswordEmailHandler
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> SendConfirmationEmail(ConfirmationEmail command, CancellationToken cancellationToken)
    {
        await confirmationEmailHandler.HandleAsync(command, cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> SendResetPasswordEmail(ResetPasswordEmail command, CancellationToken cancellationToken)
    {
        await resetPasswordEmailHandler.HandleAsync(command, cancellationToken);
        return Ok();
    }
}