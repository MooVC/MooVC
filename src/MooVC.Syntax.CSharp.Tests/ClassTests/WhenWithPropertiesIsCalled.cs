namespace MooVC.Syntax.CSharp.ClassTests;

using System.Collections.Immutable;

public sealed class WhenWithPropertiesIsCalled
{
    [Test]
    public async Task GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        Property[] existing = [new() { Name = new("First"), Type = typeof(int) }];
        Property[] additional = [new() { Name = new("Second"), Type = typeof(string) }];
        Class original = ClassTestsData.Create(properties: existing.ToImmutableArray());

        // Act
        Class result = original.WithProperties(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Properties).IsEquivalentTo([.. original.Properties, .. additional]);
        _ = await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        _ = await Assert.That(original.Properties).IsEquivalentTo(existing);
    }
}