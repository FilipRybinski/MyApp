using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.SignIn;

public record SignIn(string Email, string Password) : ICommand;
