namespace MooVC.Syntax.CSharp.Attributes.Project.ItemTests;

using System.Linq;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithMetadataIsCalled
{
    [Fact]
    public void GivenMetadataThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata existing = ItemTestsData.CreateMetadata();

        var additional = new Metadata
        {
            Name = new Identifier("Other"),
            Value = Snippet.From("Value"),
        };

        Item original = ItemTestsData.Create(metadata: existing);

        // Act
        Item result = original.WithMetadata(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Metadata.ShouldBe(original.Metadata.Concat([additional]));
        result.Condition.ShouldBe(original.Condition);
        result.Include.ShouldBe(original.Include);
    }
}