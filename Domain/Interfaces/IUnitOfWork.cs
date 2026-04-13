namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IMovieRepository MovieRepository { get; }

    public ICinemaRepository CinemaRepository { get; }

    public IRoomRepository RoomRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
