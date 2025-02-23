using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Core.Options;

namespace RequestClient.Handler;

internal class RequestHandler(IOptions<OutsideAuthorizationOptions> options,HttpClient httpClient) : IRequestHandler
{
    private const string AuthBearer = "Bearer";
    private readonly string _audience = options.Value.Audience;
    private readonly TimeSpan _expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
    private readonly string _issuer = options.Value.Issuer;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    private readonly SigningCredentials _signingCredentials = new(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey)),
        SecurityAlgorithms.HmacSha256);
    
    
    public async Task<TResponse> SendRequestAsync<TResponse>(string url, HttpMethod method)
    {
        using var request = new HttpRequestMessage(method, url);
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(AuthBearer, CreateToken());

        using var response = await httpClient.SendAsync(request);
        return await DeserializeResponseAsync<TResponse>(response);
    }

    public async Task<TResponse> SendRequestAsync<TRequest, TResponse>(string url, HttpMethod method, TRequest body)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

        using var request = new HttpRequestMessage(method, url);
        request.Content = jsonContent;
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(AuthBearer, CreateToken());

        using var response = await httpClient.SendAsync(request);
        return await DeserializeResponseAsync<TResponse>(response);
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
    
    private static async Task<TResponse> DeserializeResponseAsync<TResponse>(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
    
        return JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}