namespace MeetingMinutes.Domain.Entities;

public class MeetingMinutesMaster
{
    public int Id { get; set; }
    public string CustomerType { get; set; }
    public int? CustomerId { get; set; }
    public DateTime MeetingDate { get; set; }
    public TimeSpan MeetingTime { get; set; }
    public string MeetingPlace { get; set; }
    public string MeetingAgenda { get; set; }
    public string MeetingDecision { get; set; }
    public string ClientAttendees { get; set; }
    public string HostAttendees { get; set; }
    public DateTime CreatedDate { get; set; }
}