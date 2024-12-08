using Identity.Core.DTO;
using Shared.Abstractions;

namespace Identity.Application.Queries.SignUp;

public record SignUp(
    string Email,
    string Username,
    string Name,
    string Surname,
    string Password): IQuery<IdentityDto>;
