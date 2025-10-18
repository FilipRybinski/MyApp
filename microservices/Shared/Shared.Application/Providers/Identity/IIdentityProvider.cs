namespace Shared.Application.Providers.Identity;

public interface IIdentityProvider
{
    Guid? ExtractUserIdentityIdentifier();
}