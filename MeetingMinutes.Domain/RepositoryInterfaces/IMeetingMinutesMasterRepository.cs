using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Infrastructure.Repositories
{
    public interface IMeetingMinutesMasterRepository
    {
        Task<int> SaveMasterAsync(MeetingMinutesMaster master);
    }
}