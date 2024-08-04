

using Common.Abstractions;
using MyApp.Core.DTO;

namespace MyApp.Application.Queries.SignUp;

public record SignUp(
    string Email,
    string Username,
    string Name,
    string Surname,
    string Password): IQuery<UserDto>;
