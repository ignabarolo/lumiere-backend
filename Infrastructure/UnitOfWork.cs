using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public readonly AppDbContext _context;
    public IMovieRepository MovieRepository { get; }
    public ICinemaRepository CinemaRepository { get; }
    public IRoomRepository RoomRepository { get; }

    public UnitOfWork(AppDbContext context,
        IMovieRepository movieRepository,
        ICinemaRepository cinemaRepository,
        IRoomRepository roomRepository)
    {
        _context = context;
        MovieRepository = movieRepository;
        CinemaRepository = cinemaRepository;
        RoomRepository = roomRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
