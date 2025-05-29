using QueueMailer.Application.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.PreparePasswordSubmissionEmail;

public class PasswordSubmissionEmailHandler(IEmailTemplateReader templateReader)
    : ICommandHandler<PasswordSubmissionEmail, TemplateDto>
{
    public async Task<Result<TemplateDto>> Handle(PasswordSubmissionEmail request, CancellationToken cancellationToken)
    {
        return await templateReader.ReadEmailTemplateAsync(request, nameof(PasswordSubmissionEmail));
    }
}