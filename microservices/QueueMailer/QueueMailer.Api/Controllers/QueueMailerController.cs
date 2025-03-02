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
public class QueueMailerController(
    ILogger<QueueMailerController> logger,
    ICommandHandler<ConfirmationEmail> confirmationEmailHandler,
    ICommandHandler<ResetPasswordEmail> resetPasswordEmailHandler
    ) : ControllerBase
{
    
    [HttpPost]
    public async Task<ActionResult> SendConfirmationEmail(ConfirmationEmail command)
    {
        await confirmationEmailHandler.HandleAsync(command);
        return Ok();
    }
    
    [HttpPost]
    public async Task<ActionResult> SendResetPasswordEmail(ResetPasswordEmail command)
    {
        await resetPasswordEmailHandler.HandleAsync(command);
        return Ok();
    }
}