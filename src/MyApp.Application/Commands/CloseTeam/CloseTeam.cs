using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.CloseTeam;

public record CloseTeam(string Name) : ICommand;