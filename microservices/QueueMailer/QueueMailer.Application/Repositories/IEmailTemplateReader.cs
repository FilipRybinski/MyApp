using Shared.Application.Commands.Prepare;
using Shared.Core.DTO;

namespace QueueMailer.Application.Repositories;

public interface IEmailTemplateReader
{
    public Task<TemplateDto> ReadEmailTemplateAsync(PrepareEmail command, string fileName);
}