namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenWithIndexersIsCalled
{
    [Test]
    public async Task GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Indexer { Parameter = new() { Name = "Item" } };
        var appended = new Indexer { Parameter = new() { Name = "Other" } };
        Record original = RecordTestsData.Create(indexers: [existing]);

        // Act
        Record result = original.WithIndexers(appended);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Indexers).IsEquivalentTo([existing, appended]);
        _ = await Assert.That(result.IsPartial).IsEqualTo(original.IsPartial);
    }
}