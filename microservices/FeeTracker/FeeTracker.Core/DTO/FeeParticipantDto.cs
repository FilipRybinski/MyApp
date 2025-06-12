namespace FeeTracker.Core.DTO;

public class FeeParticipantDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public bool HasPaid { get; set; }
}