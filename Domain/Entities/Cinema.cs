namespace Domain.Entities;

public class Cinema : BaseEntity
{
    public string Address { get; set; } = string.Empty;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
