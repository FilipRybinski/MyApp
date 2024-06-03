namespace MyApp.Core.Entities;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Role(string name)
    {
        Name = name;
    }
    
}