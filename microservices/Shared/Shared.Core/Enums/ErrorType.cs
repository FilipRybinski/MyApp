namespace Shared.Core.Enums;

public enum ErrorType
{
    BadRequest = 1,
    Unauthorized = 2,
    Forbidden = 3,
    NotFound = 4,
    Conflict = 5,
    InternalServerError = 6,
    Timeout = 7,
    Validation = 8
}