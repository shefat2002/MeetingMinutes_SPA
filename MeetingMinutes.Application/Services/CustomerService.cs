using MeetingMinutes.Application.ServiceInterface;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Repositories;

namespace MeetingMinutes.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    public CustomerService(
        ICorporateCustomerRepository corporateCustomerRepository,
        IIndividualCustomerRepository individualCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _individualCustomerRepository = individualCustomerRepository;
    }
    public async Task<IEnumerable<CorporateCustomer>> GetAllCorporateCustomersAsync()
    {
        return await _corporateCustomerRepository.GetAllCorporateCustomersAsync();
    }
    public async Task<IEnumerable<IndividualCustomer>> GetAllIndividualCustomersAsync()
    {
        return await _individualCustomerRepository.GetAllIndividualCustomersAsync();
    }
}
