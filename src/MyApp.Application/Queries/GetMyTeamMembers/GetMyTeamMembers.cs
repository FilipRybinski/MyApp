using MyApp.Application.Abstractions;
using MyApp.Core.DTO;

namespace MyApp.Application.Queries.GetMyTeamMembers;

public record GetMyTeamMembers(Guid Id) : IQuery<IEnumerable<UserDto>>;
