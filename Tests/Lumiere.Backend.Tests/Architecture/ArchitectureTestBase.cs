using Infrastructure;
using NetArchTest.Rules;
using System.Reflection;

namespace Lumiere.Backend.Tests.Architecture;

public abstract class ArchitectureTestBase
{
    protected static readonly Assembly DomainAssembly = typeof(Domain.Entities.BaseEntity).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(Application.AppDependencyInjection).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(UnitOfWork).Assembly;
    protected static readonly Assembly WebAssembly = typeof(Program).Assembly;

    protected static Types GetDomainTypes() => Types.InAssembly(DomainAssembly);
    protected static Types GetApplicationTypes() => Types.InAssembly(ApplicationAssembly);
    protected static Types GetInfrastructureTypes() => Types.InAssembly(InfrastructureAssembly);
    protected static Types GetWebTypes() => Types.InAssembly(WebAssembly);
}
