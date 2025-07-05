namespace MeetingMinutes.Domain.Entities;

public class ProductService
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}