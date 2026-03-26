using Domain.Enums;

namespace Domain.Entities;

public class Booking : BaseEntity
{
    public DateTime Date { get; set; }
    public decimal Total { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public Guid ScreeningId { get; set; }
    public virtual Screening Screening { get; set; } = null!;
}
