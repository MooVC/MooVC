namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Linq;
using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenWithMetadataIsCalled
{
    [Test]
    public async Task GivenMetadataThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata existing = ResourceTestsData.CreateMetadata();
        var additional = new Metadata { Name = "Other", Value = "Other" };
        Resource original = ResourceTestsData.Create(metadata: existing);

        // Act
        Resource result = original.WithMetadata(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Metadata).IsEqualTo(original.Metadata.Concat([additional]));
        _ = await Assert.That(result.Headers).IsEqualTo(original.Headers);
    }
}