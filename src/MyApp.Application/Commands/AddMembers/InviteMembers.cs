using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.AddMembers;

public record InviteMembers(IEnumerable<Guid> Members) : ICommand;