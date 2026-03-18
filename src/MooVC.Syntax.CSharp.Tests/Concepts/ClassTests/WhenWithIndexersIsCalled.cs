namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Indexers).IsEqualTo(original.Indexers.Concat(additional));
        _ = await Assert.That(result.IsStatic).IsEqualTo(original.IsStatic);
        _ = await Assert.That(original.Indexers).IsEqualTo(existing);
    }
}