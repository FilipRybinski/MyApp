using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.InviteMembers;

public record InviteMembers(IEnumerable<Guid> Members) : ICommand;