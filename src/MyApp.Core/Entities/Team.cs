namespace MyApp.Core.Entities;

public class Team
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid OwnerId { get; private set; }

    public virtual User Owner { get; private set; }
    public virtual IEnumerable<User> Members { get; private set; }
}