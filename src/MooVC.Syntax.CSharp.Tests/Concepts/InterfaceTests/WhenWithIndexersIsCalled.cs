namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithIndexersIsCalled
{
    [Test]
    public async Task GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        var indexer = new Indexer { Parameter = new Parameter { Name = "Item" } };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithIndexers(indexer);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Indexers).Contains(indexer);
        _ = await Assert.That(original.Indexers).IsEmpty();
    }
}