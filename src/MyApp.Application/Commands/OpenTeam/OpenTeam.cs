using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.OpenTeam;

public record OpenTeam(string Name) : ICommand;