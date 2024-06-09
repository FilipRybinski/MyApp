using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands.CloseTeam;
using MyApp.Application.Commands.OpenTeam;

namespace MyApp.Api.Controllers;

public class TeamController : ControllerBase
{
    public TeamController()
    {
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