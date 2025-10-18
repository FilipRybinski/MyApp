using Identity.Core.DTO;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;

namespace Identity.Application.Queries.SignUp;

public record SignUp(
    string Email,
    string Username,
    string Name,
    string Surname,
    string Password): IQuery<IdentityDto>;
