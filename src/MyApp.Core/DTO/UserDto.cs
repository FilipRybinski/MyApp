namespace MyApp.Core.DTO;

public class UserDto
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
   
}