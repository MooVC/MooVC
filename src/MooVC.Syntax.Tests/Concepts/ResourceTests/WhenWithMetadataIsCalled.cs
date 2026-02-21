namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Linq;
using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenWithMetadataIsCalled
{
    [Fact]
    public void GivenMetadataThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata existing = ResourceTestsData.CreateMetadata();
        var additional = new Metadata { Name = "Other", Value = "Other" };
        Resource original = ResourceTestsData.Create(metadata: existing);

        // Act
        Resource result = original.WithMetadata(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Metadata.ShouldBe(original.Metadata.Concat([additional]));
        result.Headers.ShouldBe(original.Headers);
    }
}