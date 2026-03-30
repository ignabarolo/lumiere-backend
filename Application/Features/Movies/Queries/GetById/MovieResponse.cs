namespace Application.Features.Movies.Queries.GetById;

public record MovieResponse(Guid Id, string Title, string Genre);
