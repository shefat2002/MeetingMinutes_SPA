using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeetingMinutes.Web.Models;

public class MeetingMinutesViewModel
{
    [Required(ErrorMessage = "Customer type is required.")]
    public CustomerType CustomerType { get; set; } = CustomerType.Corporate;
    [Required(ErrorMessage = "Customer Name is required.")]
    public int CustomerId { get; set; }
    [Required(ErrorMessage = "Meeting date is required.")]
    [DataType(DataType.Date)]
    public DateTime MeetingDate { get; set; }
    
    [Required(ErrorMessage = "Meeting time is required.")]
    [DataType(DataType.Time)]
    public TimeSpan MeetingTime { get; set; }
    [Required(ErrorMessage = "Meeting place is required.")]
    [StringLength(200)]
    public string MeetingPlace { get; set; }
    [Required(ErrorMessage = "Meeting agenda is required.")]
    public string MeetingAgenda { get; set; }
    [Required(ErrorMessage = "Meeting discussion is required.")]
    public string MeetingDiscussion { get; set; }
    [Required(ErrorMessage = "Meeting decision is required.")]
    public string MeetingDecision { get; set; }
    [Required(ErrorMessage = "Client attendees are required.")]
    public string ClientAttendees { get; set; }
    [Required(ErrorMessage = "Host attendees are required.")]
    public string HostAttendees { get; set; }

    public List<MeetingMinutesDetailsViewModel> Details { get; set; } = new List<MeetingMinutesDetailsViewModel>();
    public IEnumerable<CorporateCustomer> CorporateCustomers { get; set; }
    public IEnumerable<IndividualCustomer> IndividualCustomers { get; set; }
    public IEnumerable<ProductService> ProductsServices { get; set; }
}

public class MeetingMinutesDetailsViewModel
{
    public int Id { get; set; }
    public int MeetingMinutesId { get; set; }
    public string ProductServiceName { get; set; }
    public int Quantity { get; set; }
    public int Unit { get; set; }
}