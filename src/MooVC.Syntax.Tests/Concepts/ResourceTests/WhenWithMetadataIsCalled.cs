namespace MooVC.Syntax.Concepts.ResourceTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Metadata).IsEquivalentTo([.. original.Metadata, additional]);
        _ = await Assert.That(result.Headers).IsEqualTo(original.Headers);
    }
}