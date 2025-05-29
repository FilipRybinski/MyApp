namespace Shared.Application.Events;

public record EmailEvent(string Email, string TemplateBody);