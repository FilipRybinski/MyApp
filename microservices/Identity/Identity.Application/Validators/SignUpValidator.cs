using FluentValidation;
using Identity.Core.Repositories;

namespace Identity.Application.Validators;

internal class SignUpValidator : AbstractValidator<Queries.SignUp.SignUp>
{
    private readonly IUserIdentityRepository _userIdentityRepository;
    private const int MinLength = 3;
    private const int MaxLength = 15;
    public SignUpValidator(IUserIdentityRepository userIdentityRepository)
    {
        _userIdentityRepository = userIdentityRepository;
        RuleFor(p => p.Email)
            .EmailAddress()
            .NotEmpty()
            .Custom((value, context) =>
            {
                var result = _userIdentityRepository.IsEmailAlreadyExists(value);
                
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
                var result = _userIdentityRepository.IsUserNameAlreadyExists(value);

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