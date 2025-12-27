namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithIndexersIsCalled
{
    [Fact]
    public void GivenIndexersThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Indexer { Parameter = new Parameter { Name = "Item" } };
        var appended = new Indexer { Parameter = new Parameter { Name = "Other" } };
        Record original = RecordTestsData.Create(indexers: [existing]);

        // Act
        Record result = original.WithIndexers(appended);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Indexers.ShouldBe(new[] { existing, appended });
        result.IsPartial.ShouldBe(original.IsPartial);
    }
}