using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands;

public record SignUp(
    Guid UserId,
    string Email,
    string Username,
    string Name,
    string Surname,
    string Password,
    string Role): ICommand;
