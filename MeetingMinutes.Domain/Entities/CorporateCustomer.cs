namespace MeetingMinutes.Domain.Entities;

public class CorporateCustomer
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}