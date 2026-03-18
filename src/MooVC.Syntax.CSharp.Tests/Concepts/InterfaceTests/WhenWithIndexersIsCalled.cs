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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Indexers).Contains(indexer);
        await Assert.That(original.Indexers).IsEmpty();
    }
}