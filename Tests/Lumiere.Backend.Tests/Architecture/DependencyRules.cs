using Xunit;

namespace Lumiere.Backend.Tests.Architecture;

public class DependencyRules : ArchitectureTestBase
{
    [Fact]
    public void Domain_Should_Not_Depend_On_Any_Other_Layer()
    {
        var result = GetDomainTypes()
            .ShouldNot()
            .HaveDependencyOnAny(
                "Application",
                "Infrastructure",
                "Microsoft.AspNetCore",
                "Microsoft.EntityFrameworkCore")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure()
    {
        var result = GetApplicationTypes()
            .ShouldNot()
            .HaveDependencyOn("Infrastructure")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void Domain_Should_Not_Depend_On_MediatR_Or_Mapster()
    {
        var result = GetDomainTypes()
            .ShouldNot()
            .HaveDependencyOnAny("MediatR", "Mapster")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }
}
