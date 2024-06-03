namespace MyApp.Core.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public Guid RoleId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public virtual Role Role { get; private set; }

    public User( string email, string username, string password, string name, string surname, Guid roleId)
    {
        Id = new Guid();
        Email = email;
        Username = username;
        Password = password;
        Name = name;
        Surname = surname;
        RoleId = roleId;
        CreatedAt = DateTime.Now;
    }
}