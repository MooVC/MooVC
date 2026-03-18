namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;

public sealed class WhenWithIndexersIsCalled
{
    [Test]
    public async Task GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        Indexer[] existing = [new Indexer { Parameter = new Parameter { Name = "Item" } }];
        Indexer[] additional = [new Indexer { Parameter = new Parameter { Name = "Entry" } }];
        Class original = ClassTestsData.Create(indexers: existing.ToImmutableArray());

        // Act
        Class result = original.WithIndexers(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Indexers).IsEquivalentTo([.. original.Indexers, .. additional]);
        _ = await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        _ = await Assert.That(original.Indexers).IsEquivalentTo(existing);
    }
}