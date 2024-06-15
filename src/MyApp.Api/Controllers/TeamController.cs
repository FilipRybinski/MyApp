using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.CloseTeam;
using MyApp.Application.Commands.OpenTeam;
using MyApp.Application.Commands.UpdateMyTeam;
using MyApp.Application.Handlers.GetMyTeam;
using MyApp.Core.DTO;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ICommandHandler<CloseTeam> _closeTeamHandler;
    private readonly IGetMyTeam _getMyTeamHandler;
    private readonly ICommandHandler<OpenTeam> _openTeamHandler;
    private readonly ICommandHandler<UpdateMyTeam> _updateMyTeamHandler;

    public TeamController(
        ICommandHandler<OpenTeam> openTeamHandler,
        ICommandHandler<CloseTeam> closeTeamHandler,
        IGetMyTeam getMyTeamHandler,
        ICommandHandler<UpdateMyTeam> updateMyTeamHandler
    )
    {
        _openTeamHandler = openTeamHandler;
        _closeTeamHandler = closeTeamHandler;
        _getMyTeamHandler = getMyTeamHandler;
        _updateMyTeamHandler = updateMyTeamHandler;
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult> CreateTeam(OpenTeam command)
    {
        await _openTeamHandler.HandleAsync(command);
        return Ok();
    }

    [Authorize]
    [HttpDelete("[action]")]
    public async Task<ActionResult> CloseMyTeam(CloseTeam command)
    {
        await _closeTeamHandler.HandleAsync(command);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<TeamDto>> GetMyTeam()
    {
        var result = await _getMyTeamHandler.HandleAsync();
        return Ok(result);
    }

    [Authorize]
    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateMyTeam(UpdateMyTeam command)
    {
        await _updateMyTeamHandler.HandleAsync(command);
        return Ok();
    }
}