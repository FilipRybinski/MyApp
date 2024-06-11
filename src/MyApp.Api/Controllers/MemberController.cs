using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.InviteMembers;
using MyApp.Application.Commands.RemoveMembers;
using MyApp.Application.Queries.GetMyTeamMembers;
using MyApp.Core.DTO;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly IEmptyQueryHandler<IEnumerable<UserDto>> _getAvailableMembersHandler;
    private readonly IQueryHandler<GetMyTeamMembers,IEnumerable<UserDto>> _getMyTeamMembersHandler;
    private readonly ICommandHandler<InviteMembers> _inviteMembersHandler;
    private readonly ICommandHandler<RemoveMembers> _removeMembersHandler;

    public MemberController(ICommandHandler<InviteMembers> inviteMembers,
        ICommandHandler<RemoveMembers> removeMembersHandler,
        IEmptyQueryHandler<IEnumerable<UserDto>> getAvailableMembersHandler,
        IQueryHandler<GetMyTeamMembers,IEnumerable<UserDto>> getMyTeamMembersHandler)
    {
        _removeMembersHandler = removeMembersHandler;
        _inviteMembersHandler = inviteMembers;
        _getAvailableMembersHandler = getAvailableMembersHandler;
        _getMyTeamMembersHandler = getMyTeamMembersHandler;
    }

    [Authorize]
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAvailableMembers()
    {
        var result = await _getAvailableMembersHandler.HandleAsync();
        return Ok(result);
    }

    [Authorize]
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetMyTeamMembers([FromQuery]GetMyTeamMembers query)
    {
        var result = await _getMyTeamMembersHandler.HandleAsync(query);
        return Ok(result);
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult> InviteMembers(InviteMembers command)
    {
        await _inviteMembersHandler.HandleAsync(command);
        return Ok();
    }

    [Authorize]
    [HttpDelete("[action]")]
    public async Task<ActionResult> RemoveMembers(RemoveMembers command)
    {
        await _removeMembersHandler.HandleAsync(command);
        return Ok();
    }
}