
namespace FeeTracker.Core.DTO;

public class FeePurposeDto
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal Amount { get; private set; }
    public bool IsCompleted { get; private set; }
    public List<Guid> Participants { get; set; }
}