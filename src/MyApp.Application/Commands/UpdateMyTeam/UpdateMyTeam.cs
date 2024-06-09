using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.UpdateMyTeam;

public record UpdateMyTeam(string Name) : ICommand;