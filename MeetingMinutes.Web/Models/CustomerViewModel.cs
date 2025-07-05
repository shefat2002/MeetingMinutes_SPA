using MeetingMinutes.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeetingMinutes.Web.Models;

public class CustomerViewModel 
{
    public string CustomerType { get; set; } = "Corporate";
    public required List<CorporateCustomer> CorporateCustomers { get; set; }
    public required List<IndividualCustomer> IndividualCustomers { get; set; }
}
