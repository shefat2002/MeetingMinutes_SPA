using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeetingMinutes.Web.Models;

public class CustomerViewModel 
{
    public CustomerType CustomerType { get; set; } = CustomerType.Corporate;
    public int CustomerId { get; set; }
    public IEnumerable<CorporateCustomer> CorporateCustomers { get; set; } = new List<CorporateCustomer>();
    public IEnumerable<IndividualCustomer> IndividualCustomers { get; set; } = new List<IndividualCustomer>();
}
