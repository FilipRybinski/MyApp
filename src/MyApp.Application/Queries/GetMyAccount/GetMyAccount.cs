using MyApp.Application.Abstractions;
using MyApp.Core.DTO;

namespace MyApp.Application.Queries.GetMyAccount;

public record GetMyAccount(Guid Id) : IQuery<UserDto>;