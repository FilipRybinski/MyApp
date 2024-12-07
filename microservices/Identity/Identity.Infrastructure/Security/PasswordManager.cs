using Identity.Application.Security;
using Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Security;

internal sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<_Identity> _passwordHasher;
        
    public PasswordManager(IPasswordHasher<
        _Identity> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string Secure(string password) => _passwordHasher.HashPassword(default, password);

    public bool Validate(string password, string securedPassword) =>
        _passwordHasher.VerifyHashedPassword(default, securedPassword, password)
            is PasswordVerificationResult.Success;
}

