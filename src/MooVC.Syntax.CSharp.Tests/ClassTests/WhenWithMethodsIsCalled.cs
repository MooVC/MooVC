namespace MooVC.Syntax.CSharp.ClassTests;

using System.Collections.Immutable;

public sealed class WhenWithMethodsIsCalled
{
    [Test]
    public async Task GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        Method[] existing = [new() { Name = new() { Name = "First" } }];
        Method[] additional = [new() { Name = new() { Name = "Second" } }];
        Class original = ClassTestsData.Create(methods: existing.ToImmutableArray());

        // Act
        Class result = original.WithMethods(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Methods).IsEquivalentTo([.. original.Methods, .. additional]);
        _ = await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        _ = await Assert.That(original.Methods).IsEquivalentTo(existing);
    }
}