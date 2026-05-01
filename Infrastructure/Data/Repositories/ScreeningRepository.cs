using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class ScreeningRepository : IScreeningRepository
{
    public readonly AppDbContext _context;

    public ScreeningRepository(AppDbContext context)
        => _context = context;

    public async Task AddAsync(Screening entity)
        => await _context.Screening
        .AddAsync(entity);

    public void Delete(Screening entity)
        => _context.Screening
        .Remove(entity);

    public async Task<IEnumerable<Screening>> GetAllAsync()
        => await _context.Screening
        .Where(s => s.State == State.Active)
        .Include(s => s.Movie)
        .Include(s => s.Room)
        .Include(s => s.Bookings)
        .AsNoTracking()
        .ToListAsync();

    public async Task<Screening?> GetByIdAsync(Guid id)
        => await _context.Screening
        .AsNoTracking()
        .Include(s => s.Movie)
        .Include(s => s.Room)
        .FirstOrDefaultAsync(s => s.Id == id && s.State == State.Active);

    public void Update(Screening entity)
        => _context.Screening
        .Update(entity);
}
