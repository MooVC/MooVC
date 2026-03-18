namespace MooVC.Syntax.Concepts.ResourceTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Headers).IsEquivalentTo([.. original.Headers, additional]);
        _ = await Assert.That(result.Metadata).IsEqualTo(original.Metadata);
    }
}