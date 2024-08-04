namespace MyApp.Core.Exceptions;

public sealed class InvalidCredentialsException: CustomException
{
    public InvalidCredentialsException() : base("Invalid Credentials"){}
}