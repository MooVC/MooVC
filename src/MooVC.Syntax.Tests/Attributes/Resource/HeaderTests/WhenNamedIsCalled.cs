namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Header original = HeaderTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Header result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(updated);
        _ = await Assert.That(result.Value).IsEqualTo(original.Value);
    }
}