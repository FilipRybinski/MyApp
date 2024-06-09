namespace MyApp.Core.Exceptions;

public sealed class TeamNotAlreadyCreatedException : CustomException
{
    public string Identifier;

    public TeamNotAlreadyCreatedException(string identifier) : base(
        $"A user with this {identifier} identifier has not already created a team")
    {
        Identifier = identifier;
    }
}