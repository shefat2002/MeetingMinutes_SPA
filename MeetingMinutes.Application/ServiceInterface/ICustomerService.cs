using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Application.ServiceInterface
{
    public interface ICustomerService
    {
        Task<IEnumerable<CorporateCustomer>> GetAllCorporateCustomersAsync();
        Task<IEnumerable<IndividualCustomer>> GetAllIndividualCustomersAsync();
    }
}