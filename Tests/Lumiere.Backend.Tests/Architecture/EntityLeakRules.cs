using Xunit;

namespace Lumiere.Backend.Tests.Architecture;

public class EntityLeakRules : ArchitectureTestBase
{
    [Fact]
    public void Application_Response_DTOs_Should_Not_Reference_Domain_Entities()
    {
        var result = GetApplicationTypes()
            .That()
            .ResideInNamespaceContaining("Queries")
            .And()
            .HaveNameEndingWith("Response")
            .ShouldNot()
            .HaveDependencyOn("Domain.Entities")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void Domain_Interfaces_Should_Be_In_Interfaces_Namespace()
    {
        var result = GetDomainTypes()
            .That()
            .AreInterfaces()
            .And()
            .AreNotNested()
            .Should()
            .ResideInNamespace("Domain.Interfaces")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }
}
