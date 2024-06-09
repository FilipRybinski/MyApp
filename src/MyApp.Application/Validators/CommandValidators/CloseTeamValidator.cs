using FluentValidation;
using MyApp.Application.Commands.CloseTeam;

namespace MyApp.Application.Validators.CommandValidators;

internal class CloseTeamValidator : AbstractValidator<CloseTeam>
{
    public CloseTeamValidator()
    {
        RuleFor(t => t.Name).NotEmpty();
    }
}