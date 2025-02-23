using Identity.Core.DTO;
using Shared.Core.Abstractions;

namespace Identity.Application.Queries.SignIn;

public record SignIn(string Email, string Password) : IQuery<IdentityDto>;
