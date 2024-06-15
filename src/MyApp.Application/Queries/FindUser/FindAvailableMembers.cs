using MyApp.Application.Abstractions;
using MyApp.Core.DTO;

namespace MyApp.Application.Queries.FindUser;

public record FindAvailableMembers(string Name) : IQuery<IEnumerable<UserDto>>;