using MyApp.Application.Abstractions;
using MyApp.Application.DTO;

namespace MyApp.Application.Queries.GetMyAccount;

public record GetMyAccount : IQuery<UserDto>;