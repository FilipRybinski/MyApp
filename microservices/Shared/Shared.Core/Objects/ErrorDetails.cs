namespace Shared.Core.Objects;

public record ErrorDetails(string PropertyName, string ErrorMessage)
{
    public string PropertyName { get; } = PropertyName;

    public string ErrorMessage { get; } = ErrorMessage;
}