

using Common.Abstractions;

namespace MyApp.Application.Commands.SignUp;

public record SignUp(
    string Email,
    string Username,
    string Name,
    string Surname,
    string Password): ICommand;
