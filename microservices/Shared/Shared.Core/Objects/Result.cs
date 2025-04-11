using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Enums;

namespace Shared.Core.Objects;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; }

    protected Result(bool isSuccess, Error? error = default)
    {
        if (isSuccess && error is not null ||
            !isSuccess && error is null)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }
    
    public static Result Success() => new(true);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true);
    public static Result Failure(Error error) => new(false, error);
    protected static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    public static ActionResult<Result> MatchResponse(Result result) => ToActionResult(result);    
    public static ActionResult<Result<TValue>> MatchResponse<TValue>(Result<TValue> result) => ToActionResult(result);    
    private static ObjectResult ToActionResult(Result result) =>
        result.Error is null ? new ObjectResult(result) { StatusCode = StatusCodes.Status200OK }
        : new ObjectResult(result) { StatusCode = (int)result.Error.StatusCode };

}

public class Result<TValue>(TValue? value, bool isSuccess, Error? error = default) : Result(isSuccess, error)
{
    public TValue? Data { get; } = value;
    public static implicit operator Result<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.BadRequest("Value cannot be null"));
    public static Result<TValue> ValidationFailure(Error error) =>
        new(default, false, error);
}