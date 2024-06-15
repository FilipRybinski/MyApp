using MyApp.Application.Abstractions;
using MyApp.Core.DTO;

namespace MyApp.Application.Queries.GetUserByIdentifier;

public record GetUserByIdentifier(Guid Id) : IQuery<UserDto>;