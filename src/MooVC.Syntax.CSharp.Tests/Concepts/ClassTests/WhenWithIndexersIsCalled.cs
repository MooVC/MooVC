namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithIndexersIsCalled
{
    [Fact]
    public void GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        Indexer[] existing = [new Indexer { Parameter = new Parameter { Name = "Item" } }];
        Indexer[] additional = [new Indexer { Parameter = new Parameter { Name = "Entry" } }];
        Class original = ClassTestsData.Create(indexers: existing.ToImmutableArray());

        // Act
        Class result = original.WithIndexers(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Indexers.ShouldBe(original.Indexers.Concat(additional));
        result.IsStatic.ShouldBe(original.IsStatic);
        original.Indexers.ShouldBe(existing);
    }
}