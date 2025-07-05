namespace MeetingMinutes.Domain.Entities;

public class IndividualCustomer
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}