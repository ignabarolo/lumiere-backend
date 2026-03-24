using Domain.Enums;

namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? Modified { get; set; }
    public string? ModifiedBy { get; set; }
    public State State { get; set; } = State.Active;
}