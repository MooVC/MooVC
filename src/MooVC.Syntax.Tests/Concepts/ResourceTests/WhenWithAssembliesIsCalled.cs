namespace MooVC.Syntax.Concepts.ResourceTests;

using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenWithAssembliesIsCalled
{
    [Test]
    public async Task GivenAssembliesThenReturnsUpdatedInstance()
    {
        // Arrange
        Assembly existing = ResourceTestsData.CreateAssembly();
        var additional = new Assembly { Alias = "Other", Name = "Other" };
        Resource original = ResourceTestsData.Create(assembly: existing);

        // Act
        Resource result = original.WithAssemblies(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Assemblies).IsEquivalentTo([.. original.Assemblies, additional]);
        _ = await Assert.That(result.Data).IsEqualTo(original.Data);
    }
}