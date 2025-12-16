namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithIndexersIsCalled
{
    [Fact]
    public void GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        var indexer = new Indexer { Parameter = new Parameter { Name = "Item" } };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithIndexers(indexer);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Indexers.ShouldContain(indexer);
        original.Indexers.ShouldBeEmpty();
    }
}