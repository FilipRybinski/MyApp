using MyApp.Application.Abstractions;
using MyApp.Core.DTO;

namespace MyApp.Application.Queries.SignIn;

public record SignIn(string Email, string Password) : IQuery<UserDto>;
