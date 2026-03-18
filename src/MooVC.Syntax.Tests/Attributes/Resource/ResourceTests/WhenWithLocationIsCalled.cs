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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.CustomToolNamespace).IsEqualTo(original.CustomToolNamespace);
        await Assert.That(result.Designer).IsEqualTo(original.Designer);
        await Assert.That(result.Location).IsEqualTo(updated);
        await Assert.That(result.Visibility).IsEqualTo(original.Visibility);
    }
}