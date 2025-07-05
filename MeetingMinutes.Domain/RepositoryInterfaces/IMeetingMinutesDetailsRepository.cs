using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Infrastructure.Repositories
{
    public interface IMeetingMinutesDetailsRepository
    {
        Task SaveDetailsAsync(MeetingMinutesDetail details);
    }
}