using Application.Features.Movies.Queries.GetById;
using Application.Features.Movies.Queries.GetList;
using Domain.Entities;
using Xunit;

namespace Lumiere.Backend.Tests.Integration.Mapping;

public class MovieMappingTests : MappingTestBase
{
    [Fact]
    public void Movie_Entity_Maps_To_MovieResponse()
    {
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = "The Matrix",
            Genre = "Action",
            Duration = TimeSpan.FromMinutes(136),
            Classification = "R"
        };

        var response = Mapper.Map<MovieResponse>(movie);

        Assert.NotNull(response);
        Assert.Equal(movie.Id, response.Id);
        Assert.Equal(movie.Title, response.Title);
        Assert.Equal(movie.Genre, response.Genre);
        Assert.Equal(movie.Duration, response.Duration);
        Assert.Equal(movie.Classification, response.Classification);
    }

    [Fact]
    public void Movie_Entity_Maps_To_MovieListResponse()
    {
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = "Interstellar",
            Genre = "Sci-Fi",
            Duration = TimeSpan.FromMinutes(169),
            Classification = "PG-13"
        };

        var response = Mapper.Map<MovieListResponse>(movie);

        Assert.NotNull(response);
        Assert.Equal(movie.Id, response.Id);
        Assert.Equal(movie.Title, response.Title);
        Assert.Equal(movie.Genre, response.Genre);
        Assert.Equal(movie.Duration, response.Duration);
        Assert.Equal(movie.Classification, response.Classification);
    }
}
