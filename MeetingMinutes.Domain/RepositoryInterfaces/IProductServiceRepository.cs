using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Infrastructure.Repositories
{
    public interface IProductServiceRepository
    {
        Task<IEnumerable<ProductService>> GetAllProductServicesAsync();
        Task<ProductService> GetProductServiceByIdAsync(int id);
    }
}