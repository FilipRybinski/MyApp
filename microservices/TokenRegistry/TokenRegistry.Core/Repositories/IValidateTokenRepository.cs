namespace TokenRegistry.Core.Repositories;

public interface IValidateTokenRepository
{
    public Task<bool> ValidateTokenAsync(string token);
}