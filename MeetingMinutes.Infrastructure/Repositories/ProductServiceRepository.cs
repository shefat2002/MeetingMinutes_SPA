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
            const string sql = "SELECT Id, Name as ProductServiceName FROM Products_Service_Tbl WHERE IsActive = 1";
            var result = await connection.QueryAsync<ProductService>(sql);
            return result;
        }
        public async Task<ProductService> GetProductServiceByIdAsync(int id)
        {
            using var connection = _dbContext.CreateConnection();
            const string sql = "SELECT Id, Name as ProductServiceName FROM Products_Service_Tbl WHERE Id = @Id AND IsActive = 1";
            var result = await connection.QueryFirstOrDefaultAsync<ProductService>(sql, new { Id = id });
            return result;
        }
    }
}
