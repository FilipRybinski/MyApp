namespace Shared.Core.Abstractions;

public interface IQueuesDefinition
{
    Dictionary<string, Func<string, Task>> Definition { get; }
}