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
        await connection.ExecuteAsync(
            "Meeting_Minutes_Details_Save_SP",
            new
            {
                details.MasterId,
                details.ProductServiceId,
                details.Quantity,
                details.Unit
            },
            commandType: CommandType.StoredProcedure
        );
    }

}