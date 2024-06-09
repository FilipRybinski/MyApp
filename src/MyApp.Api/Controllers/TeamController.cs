using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.CloseTeam;
using MyApp.Application.Commands.OpenTeam;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ICommandHandler<CloseTeam> _closeTeamHandler;
    private readonly ICommandHandler<OpenTeam> _openTeamHandler;

    public TeamController(ICommandHandler<OpenTeam> openTeamHandler, ICommandHandler<CloseTeam> closeTeamHandler)
    {
        _openTeamHandler = openTeamHandler;
        _closeTeamHandler = closeTeamHandler;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CreateTeam(OpenTeam command)
    {
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> CloseMyTeam(CloseTeam command)
    {
        return Ok();
    }
}