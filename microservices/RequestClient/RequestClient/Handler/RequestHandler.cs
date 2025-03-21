using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RequestClient.DTO;
using RequestClient.Exceptions;
using Shared.Core.Configuration;

namespace RequestClient.Handler;

internal sealed class RequestHandler(
    IOptions<InternalAuthorizationConfiguration> options,
    HttpClient httpClient,
    ILogger<RequestHandler> logger) : IRequestHandler
{
    private readonly string _audience = options.Value.Audience;
    private readonly TimeSpan _expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
    private readonly string _issuer = options.Value.Issuer;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    private readonly SigningCredentials _signingCredentials = new(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey)),
        SecurityAlgorithms.HmacSha256);
    
    
    public async Task<RequestClientResponse<TResponse>> SendRequestAsync<TRequest, TResponse>(string url, HttpMethod method, CancellationToken cancellationToken, TRequest? body = default) where TRequest : class where TResponse : class
    {
        
        try
        {
            using var request = new HttpRequestMessage(method, url);

            if (body is not null)
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
                request.Content = jsonContent;
            }

            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", CreateToken());

            using var response = await httpClient.SendAsync(request,cancellationToken);
            
            var requestClientResponse = 
                new RequestClientResponse<TResponse>()
                {
                    HttpResponse = response,
                };
            
            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

            if (responseContent == string.Empty) return requestClientResponse;
            
            requestClientResponse.DeserializedResponseBody = DeserializeResponseAsync<TResponse>(responseContent);
            return requestClientResponse;

        }
        catch (Exception e)
        {
            logger.LogWarning("Internal request failed: {ErrorMessage}", e.Message);
            throw new RequestClientException();
        }
    }
    
    private string CreateToken()
    {
        var now = DateTime.Now;
        var expires = now.Add(_expiry);
        var assemblyId = Assembly.GetCallingAssembly().GetName().FullName;
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier,assemblyId),
            new(JwtRegisteredClaimNames.Sub, assemblyId),
            new(JwtRegisteredClaimNames.UniqueName, assemblyId),
        };

        var jwt = new JwtSecurityToken(_issuer, _audience, claims, now, expires, _signingCredentials);
        var accessToken = _jwtSecurityTokenHandler.WriteToken(jwt);

        return accessToken;
    }
    
    private static  TResponse DeserializeResponseAsync<TResponse>(string responseContent) => 
        JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

}