namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IMovieRepository MovieRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
