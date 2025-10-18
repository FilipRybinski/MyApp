using QueueMailer.Application.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.PrepareConfirmationEmail;

public sealed class PrepareConfirmationEmailHandler(IEmailTemplateReader templateReader) : ICommandHandler<ConfirmationEmail, TemplateDto>
{
    public async Task<Result<TemplateDto>> Handle(ConfirmationEmail request, CancellationToken cancellationToken)
    {
        return await templateReader.ReadEmailTemplateAsync(request, nameof(ConfirmationEmail));
    }
}