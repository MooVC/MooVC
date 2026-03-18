namespace MooVC.Syntax.Project.ItemTests;

public sealed class WhenWithMetadataIsCalled
{
    [Test]
    public async Task GivenMetadataThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata existing = ItemTestsData.CreateMetadata();

        var additional = new Metadata
        {
            Name = new Name("Other"),
            Value = Snippet.From("Value"),
        };

        Item original = ItemTestsData.Create(metadata: existing);

        // Act
        Item result = original.WithMetadata(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Metadata).IsEquivalentTo([.. original.Metadata, additional]);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}