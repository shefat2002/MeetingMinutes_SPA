using System.Data;

namespace MeetingMinutes.Infrastructure.DBContext;

public interface IDbContext
{
    IDbConnection CreateConnection();
}

