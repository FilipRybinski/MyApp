using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Commands.InviteMembers;
using MyApp.Application.Commands.RemoveMembers;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly ICommandHandler<InviteMembers> _inviteMembersHandler;
    private readonly ICommandHandler<RemoveMembers> _removeMembersHandler;

    public MemberController(ICommandHandler<InviteMembers> inviteMembers,
        ICommandHandler<RemoveMembers> removeMembersHandler)
    {
        _removeMembersHandler = removeMembersHandler;
        _inviteMembersHandler = inviteMembers;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> InviteMembers(InviteMembers command)
    {
        await _inviteMembersHandler.HandleAsync(command);
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> RemoveMembers(RemoveMembers command)
    {
        await _removeMembersHandler.HandleAsync(command);
        return Ok();
    }
}