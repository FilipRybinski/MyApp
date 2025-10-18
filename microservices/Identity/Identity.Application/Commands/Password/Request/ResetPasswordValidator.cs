using FluentValidation;
using Identity.Core.Repositories;

namespace Identity.Application.Commands.Password.Request;

internal sealed class ResetPasswordValidator : AbstractValidator<ResetPasswordRequest>
{
    private readonly IUserIdentityRepository _userIdentityRepository;
    public ResetPasswordValidator(IUserIdentityRepository userIdentityRepository)
    {
        _userIdentityRepository = userIdentityRepository;
        RuleFor(p => p.Email)
            .NotEmpty()
            .EmailAddress()
            .Custom((value, context) =>
            {
                var result = _userIdentityRepository.IsEmailAlreadyExists(value);
                if (!result)
                {
                    context.AddFailure("Email address is not valid");
                }
            });
    }
}