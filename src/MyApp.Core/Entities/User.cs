namespace MyApp.Core.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Role { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User(Guid id, string email, string password, string name, string surname, string role, DateTime createdAt)
    {
        Id = id;
        Email = email;
        Password = password;
        Name = name;
        Surname = surname;
        Role = role;
        CreatedAt = createdAt;

    }
}