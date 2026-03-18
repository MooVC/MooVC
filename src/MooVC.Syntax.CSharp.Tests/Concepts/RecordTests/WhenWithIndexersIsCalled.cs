namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithIndexersIsCalled
{
    [Test]
    public async Task GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Indexer { Parameter = new Parameter { Name = "Item" } };
        var appended = new Indexer { Parameter = new Parameter { Name = "Other" } };
        Record original = RecordTestsData.Create(indexers: [existing]);

        // Act
        Record result = original.WithIndexers(appended);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Indexers).IsEquivalentTo([existing, appended]);
        _ = await Assert.That(result.IsPartial).IsEqualTo(original.IsPartial);
    }
}