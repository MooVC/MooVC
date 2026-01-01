namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Linq;
using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenWithHeadersIsCalled
{
    [Fact]
    public void GivenHeadersThenReturnsUpdatedInstance()
    {
        // Arrange
        Header existing = ResourceTestsData.CreateHeader();
        var additional = new Header { Name = "Other", Value = "Other" };
        Resource original = ResourceTestsData.Create(header: existing);

        // Act
        Resource result = original.WithHeaders(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Headers.ShouldBe(original.Headers.Concat([additional]));
        result.Metadata.ShouldBe(original.Metadata);
    }
}