using QueueMailer.Application.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.PrepareResetPasswordEmail;

public sealed class PrepareResetPasswordEmailHandler(IEmailTemplateReader templateReader) : ICommandHandler<ResetPasswordEmail, TemplateDto>
{
    public async Task<Result<TemplateDto>> Handle(ResetPasswordEmail request, CancellationToken cancellationToken)
    {
        return await templateReader.ReadEmailTemplateAsync(request, nameof(ResetPasswordEmail));
    }
}