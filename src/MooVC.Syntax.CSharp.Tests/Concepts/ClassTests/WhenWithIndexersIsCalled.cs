namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Linq;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithIndexersIsCalled
{
    [Fact]
    public void GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        Indexer[] existing = [new Indexer { Name = new Identifier("Item") }];
        Indexer[] additional = [new Indexer { Name = new Identifier("Entry") }];
        Class original = ClassTestsData.Create(indexers: existing);

        // Act
        Class result = original.WithIndexers(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Indexers.ShouldBe(original.Indexers.Concat(additional));
        result.IsStatic.ShouldBe(original.IsStatic);
        original.Indexers.ShouldBe(existing);
    }
}
