namespace Domain.Entities;

public class User : BaseEntity
{
    public string First_Name { get; set; } = string.Empty;
    public string Last_Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
