using Dapper;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.DBContext;
using System.Data;

namespace MeetingMinutes.Infrastructure.Repositories;

public class MeetingMinutesDetailsRepository : IMeetingMinutesDetailsRepository
{
    private readonly IDbContext _dbContext;

    public MeetingMinutesDetailsRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveDetailsAsync(MeetingMinutesDetail details)
    {
        using var connection = _dbContext.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@MasterId", details.MasterId);
        parameters.Add("@ProductServiceId", details.ProductServiceId);
        parameters.Add("@Quantity", details.Quantity);
        parameters.Add("@Unit", details.Unit);

        await connection.ExecuteAsync(
            "Meeting_Minutes_Details_Save_SP",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}
