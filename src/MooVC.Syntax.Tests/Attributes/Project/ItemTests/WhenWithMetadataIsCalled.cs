namespace MooVC.Syntax.Attributes.Project.ItemTests;

using System.Linq;
using MooVC.Syntax.Elements;

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
        _ = await Assert.That(result.Metadata).IsEqualTo(original.Metadata.Concat([additional]));
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}