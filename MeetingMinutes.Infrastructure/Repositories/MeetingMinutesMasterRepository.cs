using Dapper;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.DBContext;
using System.Data;

namespace MeetingMinutes.Infrastructure.Repositories;

public class MeetingMinutesMasterRepository : IMeetingMinutesMasterRepository
{
    private readonly IDbContext _dbContext;
    public MeetingMinutesMasterRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> SaveMasterAsync(MeetingMinutesMaster master)
    {
        using var connection = _dbContext.CreateConnection();
        var masterId = await connection.QuerySingleOrDefaultAsync<int>(
            "Meeting_Minutes_Master_Save_SP",
            new
            {
                master.CustomerType,
                master.CustomerId,
                master.MeetingDate,
                master.MeetingTime,
                master.MeetingPlace,
                master.MeetingAgenda,
                master.MeetingDiscussion,
                master.MeetingDecision,
                master.ClientAttendees,
                master.HostAttendees,
                master.CreatedDate
            },
            commandType: CommandType.StoredProcedure
        );
        return masterId;
    }

}
