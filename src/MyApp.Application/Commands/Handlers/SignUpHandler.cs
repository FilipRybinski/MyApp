using MyApp.Application.Abstractions;

namespace MyApp.Application.Commands.Handlers;

public sealed class SignUpHandler : ICommandHandler<SignUp>
{
    public Task HandleAsync(SignUp command)
    {
        throw new NotImplementedException();
    }
}