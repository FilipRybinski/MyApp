using Shared.Core.Exceptions;

namespace TokenRegistry.Infrastructure.Exceptions;

internal sealed class TokenRepetitionException : CustomException
{
    public TokenRepetitionException(string message) : base(message)
    {
    }
}