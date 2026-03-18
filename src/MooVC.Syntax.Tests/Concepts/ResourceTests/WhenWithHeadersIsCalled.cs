namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Linq;
using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenWithHeadersIsCalled
{
    [Test]
    public async Task GivenHeadersThenReturnsUpdatedInstance()
    {
        // Arrange
        Header existing = ResourceTestsData.CreateHeader();
        var additional = new Header { Name = "Other", Value = "Other" };
        Resource original = ResourceTestsData.Create(header: existing);

        // Act
        Resource result = original.WithHeaders(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Headers).IsEqualTo(original.Headers.Concat([additional]));
        await Assert.That(result.Metadata).IsEqualTo(original.Metadata);
    }
}