namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Linq;
using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenWithAssembliesIsCalled
{
    [Fact]
    public void GivenAssembliesThenReturnsUpdatedInstance()
    {
        // Arrange
        Assembly existing = ResourceTestsData.CreateAssembly();
        var additional = new Assembly { Alias = "Other", Name = "Other" };
        Resource original = ResourceTestsData.Create(assembly: existing);

        // Act
        Resource result = original.WithAssemblies(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Assemblies.ShouldBe(original.Assemblies.Concat([additional]));
        result.Data.ShouldBe(original.Data);
    }
}