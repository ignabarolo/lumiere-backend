namespace Domain.Entities;

public class Room : BaseEntity
{
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }

    public Guid CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; } = null!;

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();
}
