namespace MyApp.Core.Entities;

public class Role
{
    public Role(string name)
    {
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public virtual IEnumerable<User> Users { get; private set; }
}