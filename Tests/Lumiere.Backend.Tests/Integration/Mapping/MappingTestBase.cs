using Mapster;
using MapsterMapper;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace Lumiere.Backend.Tests.Integration.Mapping;

public abstract class MappingTestBase
{
    protected readonly IMapper Mapper;

    protected MappingTestBase()
    {
        var config = new TypeAdapterConfig();
        config.Scan(typeof(Application.AppDependencyInjection).Assembly);
        Mapper = new Mapper(config);
    }

    protected static JsonSerializerOptions JsonOptions => new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() }
    };

    protected void AssertCommandMapping<TCommand, TEntity>(
        string json,
        Action<TEntity>? additionalAssertions = null)
        where TCommand : class
        where TEntity : class
    {
        var command = JsonSerializer.Deserialize<TCommand>(json, JsonOptions);
        Assert.NotNull(command);

        var entity = Mapper.Map<TEntity>(command);
        Assert.NotNull(entity);

        additionalAssertions?.Invoke(entity);
    }
}
