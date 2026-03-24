namespace Domain.Entities;

public class Screening : BaseEntity
{
    public DateTime Start_Date { get; set; }
    public DateTime End_Date { get; set; }

    public Guid Room_ID { get; set; }
    public virtual Room Room { get; set; } = null!;

    public Guid Movie_ID { get; set; }
    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
