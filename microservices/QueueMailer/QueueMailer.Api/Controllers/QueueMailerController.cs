using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Commands.SendConfirmationEmail;
using Shared.Application.Commands.SendResetPasswordEmail;
using Shared.Core.Objects;
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
    public async Task<ActionResult<Result>> SendConfirmationEmail(ConfirmationEmail command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<Result>> SendResetPasswordEmail(ResetPasswordEmail command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
}