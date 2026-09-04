namespace MooVC.Syntax.CSharp.InterfaceTests;

public sealed class WhenWithIndexersIsCalled
{
    [Test]
    public async Task GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        var indexer = new Indexer { Parameter = new() { Name = "Item" } };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithIndexers(indexer);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Indexers).Contains(indexer);
        _ = await Assert.That(original.Indexers).IsEmpty();
    }
}