using FluentValidation;
using MyApp.Application.Commands.SignUp;
using MyApp.Core.Repositories;

namespace MyApp.Application.Validators.CommandValidators;

internal class SignUpValidator : AbstractValidator<SignUp>
{
    private readonly IUserRepository _userRepository;
    private const int MinLength = 3;
    private const int MaxLength = 15;
    public SignUpValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        RuleFor(p => p.Email)
            .EmailAddress()
            .NotEmpty()
            .Custom((value, context) =>
            {
                var result = _userRepository.IsEmailAlreadyExists(value);
                
                if (result)
                {
                    context.AddFailure("This email is already in use");
                }
            });
        RuleFor(p => p.Username)
            .NotEmpty()
            .MaximumLength(MaxLength)
            .MinimumLength(MinLength)
            .Custom((value, context) =>
            {
                var result = _userRepository.IsUserNameAlreadyExists(value);

                if (result)
                {
                    context.AddFailure("This username is already in use");
                }
            });
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(MaxLength)
            .MinimumLength(MinLength);
        RuleFor(p => p.Surname)
            .NotEmpty()
            .MaximumLength(MaxLength)
            .MinimumLength(MinLength);
        RuleFor(p => p.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}