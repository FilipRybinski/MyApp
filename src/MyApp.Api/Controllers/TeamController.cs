using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.AddMembers;
using MyApp.Application.Commands.CloseTeam;
using MyApp.Application.Commands.OpenTeam;
using MyApp.Application.Commands.UpdateMyTeam;
using MyApp.Application.DTO;
using MyApp.Application.Queries.GetMyTeam;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ICommandHandler<CloseTeam> _closeTeamHandler;
    private readonly IQueryHandler<GetMyTeam, TeamDto> _getMyTeamHandler;
    private readonly ICommandHandler<InviteMembers> _inviteMembersHandler;
    private readonly ICommandHandler<OpenTeam> _openTeamHandler;
    private readonly ICommandHandler<UpdateMyTeam> _updateMyTeamHandler;

    public TeamController(
        ICommandHandler<OpenTeam> openTeamHandler,
        ICommandHandler<CloseTeam> closeTeamHandler,
        ICommandHandler<InviteMembers> inviteMembers,
        IQueryHandler<GetMyTeam, TeamDto> getMyTeamHandler,
        ICommandHandler<UpdateMyTeam> updateMyTeamHandler
    )
    {
        _openTeamHandler = openTeamHandler;
        _closeTeamHandler = closeTeamHandler;
        _inviteMembersHandler = inviteMembers;
        _getMyTeamHandler = getMyTeamHandler;
        _updateMyTeamHandler = updateMyTeamHandler;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CreateTeam(OpenTeam command)
    {
        await _openTeamHandler.HandleAsync(command);
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> CloseMyTeam(CloseTeam command)
    {
        await _closeTeamHandler.HandleAsync(command);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> InviteMembers(InviteMembers command)
    {
        await _inviteMembersHandler.HandleAsync(command);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<TeamDto>> GetMyTem(GetMyTeam query)
    {
        var result = await _getMyTeamHandler.HandleAsync(query);
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateMyTeam(UpdateMyTeam command)
    {
        await _updateMyTeamHandler.HandleAsync(command);
        return Ok();
    }
}