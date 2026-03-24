namespace Domain.Entities;

public class Movie : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; }
    public string Genre { get; set; } = string.Empty;
    public string Classification { get; set; } = string.Empty;

    public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();
}
