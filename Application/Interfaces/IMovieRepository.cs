using Domain.Entities;

namespace Application.Interfaces;

public interface IMovieRepository : IRepository<Movie>
{
    Task<IEnumerable<Movie>> GetMoviesByFilterAsync(string filter);
}
