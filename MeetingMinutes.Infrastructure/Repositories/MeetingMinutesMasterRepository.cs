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

        var parameters = new DynamicParameters();
        parameters.Add("@CustomerType", master.CustomerType);
        parameters.Add("@CustomerId", master.CustomerId);
        parameters.Add("@MeetingDate", master.MeetingDate);
        parameters.Add("@MeetingTime", master.MeetingTime);
        parameters.Add("@MeetingPlace", master.MeetingPlace);
        parameters.Add("@MeetingAgenda", master.MeetingAgenda);
        parameters.Add("@MeetingDiscussion", master.MeetingDiscussion);
        parameters.Add("@MeetingDecision", master.MeetingDecision);
        parameters.Add("@ClientAttendees", master.ClientAttendees);
        parameters.Add("@HostAttendees", master.HostAttendees);
        parameters.Add("@CreatedDate", master.CreatedDate);

        // Optional: Add output parameter if SP returns inserted Id
        parameters.Add("@MasterId", dbType: DbType.Int32, direction: ParameterDirection.Output);

        await connection.ExecuteAsync(
            "Meeting_Minutes_Master_Save_SP",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return parameters.Get<int>("@MasterId");
    }
}
