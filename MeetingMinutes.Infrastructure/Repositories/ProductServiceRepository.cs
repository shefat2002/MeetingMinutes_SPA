using Dapper;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.DBContext;

namespace MeetingMinutes.Infrastructure.Repositories
{
    public class ProductServiceRepository : IProductServiceRepository
    {
        private readonly IDbContext _dbContext;

        public ProductServiceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ProductService>> GetAllProductServicesAsync()
        {
            using var connection = _dbContext.CreateConnection();
            const string sql = "SELECT Id, Name FROM Products_Service_Tbl WHERE IsActive = 1";
            var result = await connection.QueryAsync<ProductService>(sql);
            return result;
        }
    }
}
