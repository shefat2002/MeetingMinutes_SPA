using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Application.ServiceInterface
{
    public interface IMeetingMinutesService
    {
        Task<int> SaveMeetingMinutesAsync(MeetingMinutesMaster master, IEnumerable<MeetingMinutesDetail> details);
    }
}