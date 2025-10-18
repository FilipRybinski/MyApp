using Shared.Core.Exceptions;

namespace RequestClient.Exceptions;

internal sealed class RequestClientException(string message) : CustomException(message);