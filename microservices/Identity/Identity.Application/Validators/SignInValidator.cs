using FluentValidation;

namespace Identity.Application.Validators;

internal sealed class SignInValidator : AbstractValidator<Queries.SignIn.SignIn>
{
    public SignInValidator()
    {
        RuleFor(p => p.Email).NotEmpty();
        RuleFor(p => p.Password).NotEmpty();
    }
}