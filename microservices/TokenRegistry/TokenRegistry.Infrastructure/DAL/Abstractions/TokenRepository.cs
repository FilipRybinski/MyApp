using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using TokenRegistry.Core.Abstractions;
using TokenRegistry.Core.DTO;
using TokenRegistry.Core.Enums;
using TokenRegistry.Infrastructure.Exceptions;

namespace TokenRegistry.Infrastructure.DAL.Abstractions;

internal abstract class TokenRepository(IDatabase dbContext) 
{
    protected async Task<TokenDto> GetTokenAsync(TokenQuery query, TokenType tokenType,CancellationToken cancellationToken, TimeSpan expiry = default)
    {

        
        var tokenKey = CreateTokenKey(query, tokenType);
        var token = await RetrieveTokenAsync(tokenKey);

        if (!token.IsNullOrEmpty())
        {
            throw new TokenRepetitionException("Token with this key exists.");
        }
        
        token = HandleGenerateToken();
        await dbContext.StringSetAsync(tokenKey, token, expiry);
        
        return  new TokenDto()
        {
            Token = token,
            ResourceType = query.ResourceType,
        };
    }

    protected async Task<bool> IsTokenValidAsync(TokenQuery query,string token, TokenType tokenType, CancellationToken cancellationToken)
    {
        var tokenKey = CreateTokenKey(query, tokenType);
        var dbToken = string.Empty;
        switch (tokenType)
        {
            case TokenType.OneTimeToken:
                dbToken = await dbContext.StringGetDeleteAsync(tokenKey);
                break;
            case TokenType.MultiTimeToken:
            case TokenType.LimitedTimeToken:
                dbToken = await RetrieveTokenAsync(tokenKey);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(tokenType), tokenType, null);
        }
        return dbToken.Equals(token);
    }
    
    private async Task<string?> RetrieveTokenAsync(string tokenKey)
    {
        var token= await dbContext.StringGetAsync(tokenKey);
        return token;
    }
    private static string CreateTokenKey(TokenQuery query, TokenType tokenType) => $"{tokenType}_{query.ResourceType}_{query.IdentityId.ToString()}";
    private static string HandleGenerateToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }
        return Convert.ToBase64String(randomNumber);
    }
}