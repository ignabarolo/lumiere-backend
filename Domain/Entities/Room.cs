namespace Domain.Entities;

public class Room : BaseEntity
{
    public int Room_Number { get; set; }
    public int Capacity { get; set; }

    public Guid Cinema_ID { get; set; }
    public virtual Cinema Cinema { get; set; } = null!;

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();
}
