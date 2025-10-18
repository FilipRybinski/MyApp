using Identity.Domain.Roles;
using Shared.Domain.Abstractions;

namespace Identity.Domain.Identity;

public class UserIdentity : Entity
{
    public UserIdentity(string email, string username, string password, string name, string surname, Guid roleId)
    {
        Id = Guid.NewGuid();
        Email = email;
        Username = username;
        Password = password;
        Name = name;
        Surname = surname;
        IsActive = false;
        RoleId = roleId;
        CreatedAt = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public bool IsActive { get; private set; }
    public Guid RoleId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public virtual Role Role { get; private set; }

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
    
    public void PasswordSubmission(string password) => Password = password;
}