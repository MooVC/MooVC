namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Header original = HeaderTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Header result = original.WithValue(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Value).IsEqualTo(updated);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}