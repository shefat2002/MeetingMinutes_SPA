using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Web.Models;

public class MeetingMinutesMasterViewModel
{
    public string CustomerType { get; set; }
    public int? CustomerId { get; set; }
    public DateOnly MeetingDate { get; set; }
    public TimeOnly MeetingTime { get; set; }
    public string MeetingPlace { get; set; }
    public string MeetingAgenda { get; set; }
    public string MeetingDecision { get; set; }
    public string ClientAttendees { get; set; }
    public string HostAttendees { get; set; }
    public List<CorporateCustomer> CorporateCustomers { get; set; }
    public List<IndividualCustomer> IndividualCustomers { get; set; }

}
