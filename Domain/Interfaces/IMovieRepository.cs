using Domain.Entities;

namespace Domain.Interfaces;

public interface IMovieRepository : IRepository<Movie>
{
    Task<IEnumerable<Movie>> GetMoviesByFilterAsync(string filter);
}
