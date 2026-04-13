using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class RoomRepository : IRoomRepository
{
    public readonly AppDbContext _context;

    public RoomRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(Room entity)
        => await _context.Room.AddAsync(entity);

    public void Delete(Room entity)
        => _context.Room.Remove(entity);

    public async Task<IEnumerable<Room>> GetAllAsync()
        => await _context.Room.Where(r => r.State == State.Active)
                                .Include(r => r.Seats).AsQueryable().ToListAsync();

    public async Task<Room?> GetByIdAsync(Guid id)
        => await _context.Room.AsNoTracking()
                                .Include(r => r.Seats)
                                .FirstOrDefaultAsync(r => r.Id == id && r.State == State.Active);

    public void Update(Room entity)
        => _context.Room.Update(entity);
}
