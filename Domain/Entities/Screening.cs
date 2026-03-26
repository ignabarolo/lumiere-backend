namespace Domain.Entities;

public class Screening : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid RoomId { get; set; }
    public virtual Room Room { get; set; } = null!;

    public Guid MovieId { get; set; }
    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
