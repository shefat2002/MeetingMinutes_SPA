namespace MeetingMinutes.Web.Models;

public class MeetingMinutesDetailsViewModel
{
    public int Id { get; set; }
    public int MasterId { get; set; }
    public int ProductServiceId { get; set; }
    public string ProductServiceName { get; set; }
    public int Quantity { get; set; }
    public int Unit { get; set; }
}