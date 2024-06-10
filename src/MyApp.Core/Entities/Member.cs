namespace MyApp.Core.Entities;

public class Member
{
    public Member(Guid userId, Guid teamId)
    {
        Id = new Guid();
        UserId = userId;
        TeamId = teamId;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid TeamId { get; private set; }

    public virtual User User { get; private set; }
    public virtual Team Team { get; private set; }
}