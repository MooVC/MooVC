namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithIndexersIsCalled
{
    [Fact]
    public void GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        var indexer = new Indexer { Parameter = new Parameter { Name = "Item" } };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithIndexers(indexer);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Indexers.ShouldContain(indexer);
        original.Indexers.ShouldBeEmpty();
    }
}