using FluentValidation;

namespace Identity.Application.Commands.Password.Submission;

internal sealed class PasswordSubmissionValidator : AbstractValidator<PasswordSubmission>
{
    public PasswordSubmissionValidator()
    {
        RuleFor(p=>p.Password)
            .NotEmpty()
            .MinimumLength(8);
        RuleFor(p => p.Token)
            .NotEmpty();
        RuleFor(p => p.Id)
            .NotEmpty();
    }
}