using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueueMailer.Application.Commands.PrepareActivationEmail;
using QueueMailer.Application.Commands.PrepareConfirmationEmail;
using QueueMailer.Application.Commands.PreparePasswordSubmissionEmail;
using QueueMailer.Application.Commands.PrepareResetPasswordEmail;
using QueueMailer.Application.Events;
using QueueMailer.Application.Repositories;
using Shared.Application.Events;
using Shared.Core.DTO;
using Shared.Core.Objects;
using Shared.Core.Policies;

namespace QueueMailer.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Policy = AuthPolicies.Internal)]
public sealed class QueueMailerController(
    ILogger<QueueMailerController> logger,
    ISender sender,
    IQueueMailerOutBoxRepository queueMailerOutBoxRepository
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Result<TemplateDto>>> PrepareConfirmationEmail(ConfirmationEmail command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    
    [HttpPost]
    public async Task<ActionResult<Result>> HandleConfirmationEmailEvent(ConfirmationEmailEvent command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await queueMailerOutBoxRepository.HandlePublishAsync(command, cancellationToken));
    }
    
    [HttpPost]
    public async Task<ActionResult<Result<TemplateDto>>> PrepareActivationEmail(ActivationEmail command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    
    [HttpPost]
    public async Task<ActionResult<Result>> HandleActivationEmailEvent(ActivationEmailEvent command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await queueMailerOutBoxRepository.HandlePublishAsync(command, cancellationToken));
    }
    
    [HttpPost]
    public async Task<ActionResult<Result<TemplateDto>>> PrepareResetPasswordEmail(ResetPasswordEmail command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<Result>> HandleResetPasswordEmailEvent(ResetPasswordEmailEvent command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await queueMailerOutBoxRepository.HandlePublishAsync(command, cancellationToken));
    }
    
    [HttpPost]
    public async Task<ActionResult<Result<TemplateDto>>> PreparePasswordSubmissionEmail(PasswordSubmissionEmail command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<Result>> HandlePasswordSubmissionEvent(PasswordSubmissionEmailEvent command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await queueMailerOutBoxRepository.HandlePublishAsync(command, cancellationToken));
    }
    
}