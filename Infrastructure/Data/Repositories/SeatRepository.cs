using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class SeatRepository : ISeatRepository
{
    public readonly AppDbContext _context;

    public SeatRepository(AppDbContext context)
        => _context = context;

    public async Task AddAsync(Seat entity)
        => await _context.Seat.AddAsync(entity);

    public void Delete(Seat entity)
        => _context.Seat.Remove(entity);
    public async Task<IEnumerable<Seat>> GetAllAsync()
        => await _context.Seat.Where(s => s.State == State.Active)
                                                    .OrderBy(s => s.Row)
                                                    .ThenBy(s => s.Column).AsNoTracking().ToListAsync();

    public Task<Seat?> GetByIdAsync(Guid id)
        => _context.Seat.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id && s.State == State.Active);

    public void Update(Seat entity)
        => _context.Seat.Update(entity);
}
