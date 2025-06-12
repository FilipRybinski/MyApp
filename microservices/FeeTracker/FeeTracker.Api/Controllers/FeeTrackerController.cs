using FeeTracker.Application.Commands.Contributor.Add;
using FeeTracker.Application.Commands.Participant.Attach;
using FeeTracker.Application.Commands.Participant.Detach;
using FeeTracker.Application.Commands.Participant.Paid;
using FeeTracker.Application.Commands.Purpose.Add;
using FeeTracker.Application.Commands.Purpose.Completed;
using FeeTracker.Application.Commands.Purpose.Delete;
using FeeTracker.Application.Commands.Purpose.Edit;
using FeeTracker.Application.Queries.Contributor.Get;
using FeeTracker.Application.Queries.Participants.Get;
using FeeTracker.Application.Queries.Purpose.Get;
using FeeTracker.Core.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Objects;
using Shared.Core.Policies;

namespace FeeTracker.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Policy = AuthPolicies.External)]
public class FeeTrackerController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async  Task<ActionResult<Result>> AddFeePurpose(AddFeePurpose command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    [HttpPut]
    public async  Task<ActionResult<Result>> EditFeePurpose(EditFeePurpose command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    
    [HttpDelete]
    public async  Task<ActionResult<Result>> DeleteFeePurpose([FromQuery] DeleteFeePurpose command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    
    [HttpPut]
    public async  Task<ActionResult<Result>> MarkAsCompletedFeePurpose(MarkAsCompleted command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    
    [HttpGet]
    public async Task<ActionResult<Result<List<FeePurposeDto>>>> GetFeePurposes(CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(new GetFeePurpose(), cancellationToken));
    }
    
    [HttpPost]
    public async  Task<ActionResult<Result>> AddContributor(AddFeeContributor command, CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    
    [HttpGet]
    public async  Task<ActionResult<Result<List<FeeContributorDto>>>> GetContributors(CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(new GetFeeContributor(), cancellationToken));
    }
    
    [HttpPost]
    public async  Task<ActionResult<Result>> AttachParticipant(AttachParticipant command,CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    
        
    [HttpPost]
    public async  Task<ActionResult<Result>> DetachParticipant(DetachParticipant command,CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    
    [HttpPut]
    
    public async  Task<ActionResult<Result>> MarkAsPaid(MarkAsPaid command,CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(command, cancellationToken));
    }
    
    [HttpGet]
    public async  Task<ActionResult<Result<List<FeeParticipantDto>>>> GetParticipantDetails([FromQuery] GetFeeParticipant query,CancellationToken cancellationToken)
    {
        return Result.MatchResponse(await sender.Send(query, cancellationToken));
    }
}