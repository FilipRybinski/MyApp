using QueueMailer.Application.Repositories;
using Shared.Application.Commands.Prepare;
using Shared.Core.DTO;

namespace QueueMailer.Infrastructure.Template.Reader;

public class EmailTemplateReader : IEmailTemplateReader
{
    public async Task<TemplateDto> ReadEmailTemplateAsync(PrepareEmail command, string fileName)
    {
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", $"{fileName}.html");

        if (!File.Exists(templatePath))
            throw new FileNotFoundException("Email template not found", templatePath);

        var htmlTemplate = await File.ReadAllTextAsync(templatePath);

        if (command.Link is not null)
        {
            htmlTemplate = htmlTemplate.Replace("{{Link}}", command.Link);
        }

        return new TemplateDto
        {
            TemplateBody = htmlTemplate
        };
    }
}