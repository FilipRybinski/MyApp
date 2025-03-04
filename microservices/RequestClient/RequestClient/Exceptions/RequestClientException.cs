using Shared.Core.Exceptions;

namespace RequestClient.Exceptions;

internal sealed class RequestClientException() : CustomException("Failed to create send request to internal services");