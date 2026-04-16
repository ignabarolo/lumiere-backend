namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IMovieRepository MovieRepository { get; }

    public ICinemaRepository CinemaRepository { get; }

    public IRoomRepository RoomRepository { get; }

    public ISeatRepository SeatRepository { get; }

    public IScreeningRepository ScreeningRepository { get; }

    public IBookingRepository BookingRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
