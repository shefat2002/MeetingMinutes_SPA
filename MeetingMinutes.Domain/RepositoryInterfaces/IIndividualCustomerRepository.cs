using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Infrastructure.Repositories
{
    public interface IIndividualCustomerRepository
    {
        Task<IEnumerable<IndividualCustomer>> GetAllIndividualCustomersAsync();
    }
}