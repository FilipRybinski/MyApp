
using Shared.Core.Exceptions;
using Shared.Infrastructure.Exceptions;

namespace Identity.Core.Exceptions;

public class InvalidCredentialsException() : CustomException("Invalid Credentials");