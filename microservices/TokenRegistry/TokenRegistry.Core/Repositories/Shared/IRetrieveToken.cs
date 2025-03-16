namespace TokenRegistry.Core.Repositories.Shared;

public interface IRetrieveToken
{
    public Task<string> Retrieve(string token);
}