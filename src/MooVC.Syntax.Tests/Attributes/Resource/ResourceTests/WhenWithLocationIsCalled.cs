namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithLocationIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Resource original = ResourceTestsData.Create();
        var updated = new Path("Other.resx");

        // Act
        Resource result = original.WithLocation(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.CustomToolNamespace).IsEqualTo(original.CustomToolNamespace);
        _ = await Assert.That(result.Designer).IsEqualTo(original.Designer);
        _ = await Assert.That(result.Location).IsEqualTo(updated);
        _ = await Assert.That(result.Visibility).IsEqualTo(original.Visibility);
    }
}