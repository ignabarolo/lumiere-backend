using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class CinemaRepository : ICinemaRepository
{
    public readonly AppDbContext _context;

    public CinemaRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(Cinema entity)
        => await _context.Cinema.AddAsync(entity);

    public void Delete(Cinema entity)
        => _context.Cinema.Remove(entity);

    public async Task<IEnumerable<Cinema>> GetAllAsync()
        => await _context.Cinema.Where(c => c.State == State.Active)
                                .Include(c => c.Rooms)
                                .ThenInclude(r => r.Seats)
                                .AsNoTracking().AsQueryable().ToListAsync();

    public async Task<Cinema?> GetByIdAsync(Guid id)
        => await _context.Cinema.AsNoTracking()
                                .Include(c => c.Rooms)
                                .ThenInclude(r => r.Seats)
                                .FirstOrDefaultAsync(c => c.Id == id && c.State == State.Active);

    public void Update(Cinema entity)
        => _context.Cinema.Update(entity);
}
