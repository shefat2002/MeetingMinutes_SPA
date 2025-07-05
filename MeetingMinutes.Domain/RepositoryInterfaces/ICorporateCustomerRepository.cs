using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Infrastructure.Repositories
{
    public interface ICorporateCustomerRepository
    {
        Task<IEnumerable<CorporateCustomer>> GetAllCorporateCustomersAsync();
    }
}