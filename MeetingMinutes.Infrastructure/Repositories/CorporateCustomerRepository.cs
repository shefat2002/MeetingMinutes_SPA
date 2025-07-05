using Dapper;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.DBContext;

namespace MeetingMinutes.Infrastructure.Repositories;

public class CorporateCustomerRepository : ICorporateCustomerRepository
{
    private readonly IDbContext _dbContext;
    public CorporateCustomerRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<CorporateCustomer>> GetAllCorporateCustomersAsync()
    {
        using var connection = _dbContext.CreateConnection();
        string sql = "SELECT Id, CustomerName as Name FROM Corporate_Customer_Tbl WHERE IsActive = 1";

        var result = await connection.QueryAsync<CorporateCustomer>(sql).ToString();
        return result;
    }
}
