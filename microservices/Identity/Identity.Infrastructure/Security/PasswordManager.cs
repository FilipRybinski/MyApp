using Identity.Application.Security;
using Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Security;

internal sealed class PasswordManager(
    IPasswordHasher<
        _Identity> passwordHasher) : IPasswordManager
{
    public string Secure(string password) => passwordHasher.HashPassword(default, password);

    public bool Validate(string password, string securedPassword) =>
        passwordHasher.VerifyHashedPassword(default, securedPassword, password)
            is PasswordVerificationResult.Success;
}

