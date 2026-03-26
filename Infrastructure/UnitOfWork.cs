using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) =>_context = context;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
