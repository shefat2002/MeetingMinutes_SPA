using MeetingMinutes.Application.ServiceInterface;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Repositories;

namespace MeetingMinutes.Application.Services;

public class MeetingMinutesService : IMeetingMinutesService
{
    private readonly IMeetingMinutesMasterRepository _meetingMinutesMasterRepository;
    private readonly IMeetingMinutesDetailsRepository _meetingMinutesDetailsRepository;

    public MeetingMinutesService(IMeetingMinutesMasterRepository meetingMinutesMasterRepository, IMeetingMinutesDetailsRepository meetingMinutesDetailsRepository)
    {
        _meetingMinutesMasterRepository = meetingMinutesMasterRepository;
        _meetingMinutesDetailsRepository = meetingMinutesDetailsRepository;
    }

    public async Task<int> SaveMeetingMinutesAsync(MeetingMinutesMaster master, IEnumerable<MeetingMinutesDetail> details)
    {
        var masterId = await _meetingMinutesMasterRepository.SaveMasterAsync(master);

        foreach (var detail in details)
        {
            detail.MasterId = masterId;
            await _meetingMinutesDetailsRepository.SaveDetailsAsync(detail);
        }
        return masterId;
    }

}
