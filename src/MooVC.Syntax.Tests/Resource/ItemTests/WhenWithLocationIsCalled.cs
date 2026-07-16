namespace MooVC.Syntax.Resource.ItemTests;

public sealed class WhenWithLocationIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = new Path("Other.resx");

        // Act
        Item result = original.WithLocation(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.CustomToolNamespace).IsEqualTo(original.CustomToolNamespace);
        _ = await Assert.That(result.Designer).IsEqualTo(original.Designer);
        _ = await Assert.That(result.Location).IsEqualTo(updated);
        _ = await Assert.That(result.Visibility).IsEqualTo(original.Visibility);
    }
}