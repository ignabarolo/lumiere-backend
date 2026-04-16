using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    public readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
        => _context = context;

    public async Task AddAsync(Booking entity)
        => await _context.Booking
        .AddAsync(entity);

    public void Delete(Booking entity)
        => _context.Booking
        .Remove(entity);

    public async Task<IEnumerable<Booking>> GetAllAsync()
        => await _context.Booking
        .Where(b => b.State == State.Active)
        .Include(b => b.Screening)
        .ThenInclude(s => s.Movie)
        .Include(b => b.Screening)
        .ThenInclude(s => s.Room)
        .AsNoTracking()
        .ToListAsync();

    public async Task<Booking?> GetByIdAsync(Guid id)
        => await _context.Booking
        .AsNoTracking()
        .Include(b => b.Screening)
        .ThenInclude(s => s.Movie)
        .Include(b => b.Screening)
        .ThenInclude(s => s.Room)
        .FirstOrDefaultAsync(b => b.Id == id && b.State == State.Active);

    public void Update(Booking entity)
        => _context.Booking
        .Update(entity);
}
