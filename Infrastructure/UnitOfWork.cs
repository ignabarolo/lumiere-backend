using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public readonly AppDbContext _context;
    public IMovieRepository MovieRepository { get; }

    public UnitOfWork(AppDbContext context, IMovieRepository movieRepository)
    {
        _context = context;
        MovieRepository = movieRepository;
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
