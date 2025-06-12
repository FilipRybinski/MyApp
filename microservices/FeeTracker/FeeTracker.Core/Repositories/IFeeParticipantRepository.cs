using FeeTracker.Domain.Participant;

namespace FeeTracker.Core.Repositories;

public interface IFeeParticipantRepository
{
    Task AttachParticipant(List<FeeParticipant> feeParticipant);
    
    Task<List<FeeParticipant>> GetAllPurposeParticipantsDetails(Guid id);
    
    Task MarkAsPaid(Guid id);
}