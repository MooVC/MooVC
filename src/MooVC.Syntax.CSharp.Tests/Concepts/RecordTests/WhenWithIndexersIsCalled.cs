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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Indexers).IsEqualTo(new[] { existing, appended });
        await Assert.That(result.IsPartial).IsEqualTo(original.IsPartial);
    }
}