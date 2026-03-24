namespace Domain.Entities;

public class Seat : BaseEntity
{
    public string Row { get; set; } = string.Empty;
    public int Column { get; set; }

    public Guid Room_ID { get; set; }
    public virtual Room Room { get; set; } = null!;
}
