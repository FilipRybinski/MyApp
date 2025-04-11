using System.Net;
using FluentValidation.Results;
using Shared.Core.Enums;

namespace Shared.Core.Objects;

public sealed record ValidationError(ValidationFailure[] ValidationFailures) : Error(HttpStatusCode.BadRequest,
    "One or more validation errors occurred",
    ErrorType.Validation,
    MapValidationFailuresToErrorDetails(ValidationFailures)
    )
{
    private static ErrorDetails[] MapValidationFailuresToErrorDetails(ValidationFailure[] validationFailures) =>
        validationFailures.Select(vf=>new ErrorDetails(vf.PropertyName, vf.ErrorMessage)).ToArray();
}