using FluentValidation;

namespace Identity.Application.Commands.Activation;

internal sealed class ActivationEmailActionValidator : AbstractValidator<ActivationAction>
{
    public ActivationEmailActionValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p=>p.Token).NotEmpty();
    }
}