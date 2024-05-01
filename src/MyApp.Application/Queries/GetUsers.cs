using MyApp.Application.Abstractions;
using MyApp.Application.DTO;

namespace MyApp.Application.Queries;

public record GetUsers() : IQuery<IEnumerable<UserDto>>;