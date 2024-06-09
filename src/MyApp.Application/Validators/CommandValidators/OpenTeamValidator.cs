using FluentValidation;
using MyApp.Application.Commands.OpenTeam;

namespace MyApp.Application.Validators.CommandValidators;

internal class OpenTeamValidator : AbstractValidator<OpenTeam>
{
    public OpenTeamValidator()
    {
        RuleFor(t => t.Name).NotEmpty();
    }
}