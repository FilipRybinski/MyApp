using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.AddMembers;
using MyApp.Application.Commands.CloseTeam;
using MyApp.Application.Commands.OpenTeam;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ICommandHandler<CloseTeam> _closeTeamHandler;
    private readonly ICommandHandler<InviteMembers> _inviteMembersHandler;
    private readonly ICommandHandler<OpenTeam> _openTeamHandler;

    public TeamController(
        ICommandHandler<OpenTeam> openTeamHandler,
        ICommandHandler<CloseTeam> closeTeamHandler,
        ICommandHandler<InviteMembers> inviteMembers
    )
    {
        _openTeamHandler = openTeamHandler;
        _closeTeamHandler = closeTeamHandler;
        _inviteMembersHandler = inviteMembers;
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
}