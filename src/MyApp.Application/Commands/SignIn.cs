using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands;

public record SignIn(string username, string password) : ICommand;
