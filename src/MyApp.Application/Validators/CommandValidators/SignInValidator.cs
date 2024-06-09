using FluentValidation;
using MyApp.Application.Commands.SignIn;

namespace MyApp.Application.Validators.CommandValidators;

internal class SignInValidator : AbstractValidator<SignIn>
{
    public SignInValidator()
    {
        RuleFor(p => p.Email).NotEmpty();
        RuleFor(p => p.Password).NotEmpty();
    }
}