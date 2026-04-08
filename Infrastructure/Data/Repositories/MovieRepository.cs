using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class MovieRepository : IMovieRepository
{
    public readonly AppDbContext _context;

    public MovieRepository(AppDbContext context) => _context = context;


    public async Task<Movie?> GetByIdAsync(Guid id) =>
        await _context.Movie.AsNoTracking().Include(m => m.Screenings).FirstOrDefaultAsync(w => w.Id == id && w.State == State.Active);

    public async Task<IEnumerable<Movie>> GetAllAsync() =>
        await _context.Movie.Where(w => w.State == State.Active).AsNoTracking().ToListAsync();

    public async Task AddAsync(Movie entity) =>
        await _context.Movie.AddAsync(entity);

    public void Update(Movie entity) =>
        _context.Movie.Update(entity);

    public void Delete(Movie entity) =>
        _context.Movie.Remove(entity);

    public async Task<IEnumerable<Movie>> GetMoviesByFilterAsync(string filter)
    {
        var movies = await _context.Movie.Where(w => (w.Genre.ToLower() == filter ||
                                                    w.Classification.ToLower() == filter ||
                                                    filter == string.Empty) &&
                                                    w.State == State.Active).Include(m => m.Screenings)
                                                                            .AsNoTracking()
                                                                            .AsQueryable()
                                                                            .ToListAsync();
        return movies;
    }
}
