using Identity.Domain.Identity;
using Shared.Domain.Abstractions;

namespace Identity.Domain.Roles;

public class Role : Entity
{
    public Role(string name)
    {
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public virtual IEnumerable<UserIdentity> Identities { get; private set; }
}