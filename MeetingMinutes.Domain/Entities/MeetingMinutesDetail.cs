namespace MeetingMinutes.Domain.Entities;

public class MeetingMinutesDetail
{
    public int Id { get; set; }
    public int MasterId { get; set; }
    public int ProductServiceId { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; }

}