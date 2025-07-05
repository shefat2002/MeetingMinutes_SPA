using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Application.ServiceInterface
{
    public interface IProductServiceService
    {
        Task<IEnumerable<ProductService>> GetAllProductServicesAsync();
        Task<ProductService> GetProductServiceByIdAsync(int id);
    }
}