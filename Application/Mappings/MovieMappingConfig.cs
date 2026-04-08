using Application.Features.Movies.Queries.Common;
using Application.Features.Movies.Queries.GetById;
using Application.Features.Movies.Queries.GetList;
using Domain.Entities;
using Mapster;

namespace Application.Mappings;

public class MovieMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Movie, MovieResponse>();
        config.NewConfig<Movie, MovieListResponse>();
        config.NewConfig<Screening, MovieScreeningResponse>();
    }
}
