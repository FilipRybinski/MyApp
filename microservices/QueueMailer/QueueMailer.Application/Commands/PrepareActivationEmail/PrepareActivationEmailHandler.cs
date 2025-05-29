using QueueMailer.Application.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.PrepareActivationEmail;

public sealed class PrepareActivationEmailHandler(IEmailTemplateReader templateReader) : ICommandHandler<ActivationEmail,TemplateDto>
{

    public async Task<Result<TemplateDto>> Handle(ActivationEmail request, CancellationToken cancellationToken)
    {
        return await templateReader.ReadEmailTemplateAsync(request, nameof(ActivationEmail));
    }
}