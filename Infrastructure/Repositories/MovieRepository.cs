using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    public readonly AppDbContext _context;

    public MovieRepository(AppDbContext context) => _context = context;
    

    public async Task<Movie> GetByIdAsync(int id) =>
        await _context.Movie.FindAsync(id) ?? new Movie();

    public async Task<IEnumerable<Movie>> GetAllAsync() =>
        await _context.Movie.ToListAsync();

    public async Task AddAsync(Movie entity) =>
        await _context.Movie.AddAsync(entity);

    public void Update(Movie entity) =>
        _context.Movie.Update(entity);

    public void Delete(Movie entity) =>
        _context.Movie.Remove(entity);

    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre)
    {
        var movies = await _context.Movie.Where(w => w.Genre == genre).AsNoTracking().ToListAsync();
        return movies;
    }
}
