namespace MyApp.Core.Exceptions;

public class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base("Invalid Credentials")
    {
    }
}