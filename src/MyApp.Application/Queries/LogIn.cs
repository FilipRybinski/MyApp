using MyApp.Application.Abstractions;

namespace MyApp.Application.Queries;

public record LogIn(string Email, string Password) : IQuery<bool>;
