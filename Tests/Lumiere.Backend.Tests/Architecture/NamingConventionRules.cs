using MediatR;
using Xunit;

namespace Lumiere.Backend.Tests.Architecture;

public class NamingConventionRules : ArchitectureTestBase
{
    [Fact]
    public void All_Handlers_Should_End_With_Handler()
    {
        var result = GetApplicationTypes()
            .That()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Should()
            .HaveNameEndingWith("Handler")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void All_Commands_Should_End_With_Command()
    {
        var result = GetApplicationTypes()
            .That()
            .ImplementInterface(typeof(IRequest<>))
            .And()
            .ResideInNamespaceContaining("Commands")
            .Should()
            .HaveNameEndingWith("Command")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void All_Queries_Should_End_With_Query()
    {
        var result = GetApplicationTypes()
            .That()
            .ImplementInterface(typeof(IRequest<>))
            .And()
            .ResideInNamespaceContaining("Queries")
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void All_Validators_Should_End_With_Validator()
    {
        var result = GetApplicationTypes()
            .That()
            .AreClasses()
            .And()
            .AreNotAbstract()
            .And()
            .ResideInNamespaceContaining("Commands")
            .And()
            .HaveNameEndingWith("Validator")
            .Should()
            .HaveNameEndingWith("Validator")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void Response_Types_In_Queries_Should_Not_Be_Domain_Entities()
    {
        var result = GetApplicationTypes()
            .That()
            .ResideInNamespaceContaining("Queries")
            .And()
            .AreClasses()
            .Should()
            .NotHaveNameStartingWith("Movie")
            .Or()
            .NotHaveNameStartingWith("Cinema")
            .Or()
            .NotHaveNameStartingWith("Room")
            .Or()
            .NotHaveNameStartingWith("Seat")
            .Or()
            .NotHaveNameStartingWith("Screening")
            .Or()
            .NotHaveNameStartingWith("Booking")
            .GetResult();

        Assert.True(result.IsSuccessful, string.Join(", ", result.FailingTypeNames ?? []));
    }
}
