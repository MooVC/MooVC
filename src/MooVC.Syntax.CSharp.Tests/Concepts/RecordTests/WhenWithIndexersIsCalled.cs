namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithIndexersIsCalled
{
    [Fact]
    public void GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Indexer { Name = new Identifier("Item") };
        var appended = new Indexer { Name = new Identifier("Other") };
        Record original = RecordTestsData.Create(indexers: [existing]);

        // Act
        Record result = original.WithIndexers(appended);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Indexers.ShouldBe(new[] { existing, appended });
        result.IsPartial.ShouldBe(original.IsPartial);
    }
}
