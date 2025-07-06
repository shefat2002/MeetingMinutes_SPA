using MeetingMinutes.Application.ServiceInterface;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Repositories;

namespace MeetingMinutes.Application.Services;

public class ProductServiceService : IProductServiceService
{
    private readonly IProductServiceRepository _productServiceRepository;
    public ProductServiceService(IProductServiceRepository productServiceRepository)
    {
        _productServiceRepository = productServiceRepository;
    }
    public async Task<IEnumerable<ProductService>> GetAllProductServicesAsync()
    {
        return await _productServiceRepository.GetAllProductServicesAsync();
    }
}
