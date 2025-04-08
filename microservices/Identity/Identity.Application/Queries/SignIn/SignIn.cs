using Identity.Core.DTO;
using Shared.Application.Abstractions.CQRS;

namespace Identity.Application.Queries.SignIn;

public record SignIn(string Email, string Password) : IQuery<IdentityDto>;
