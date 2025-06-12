using QueueMailer.Application.Commands.PrepareConfirmationEmail;
using QueueMailer.Application.Repositories;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;
using Shared.Core.Objects;

namespace QueueMailer.Application.Commands.PrepareCreateContributorEvent;

public class PrepareCreateContributorEmailHandler(IEmailTemplateReader templateReader) : ICommandHandler<CreateContributorEmail, TemplateDto>
{
    public async Task<Result<TemplateDto>> Handle(CreateContributorEmail request, CancellationToken cancellationToken)
    {
        return await templateReader.ReadEmailTemplateAsync(request, nameof(CreateContributorEmail));
    }
}