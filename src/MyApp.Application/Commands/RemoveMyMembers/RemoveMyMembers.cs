using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.RemoveMembers;

public record RemoveMyMembers(IEnumerable<Guid> Members) : ICommand;