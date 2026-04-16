namespace MooVC.Syntax.Resource.ItemTests;

public sealed class WhenWithVisibilityIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();

        // Act
        Item result = original.WithVisibility(Item.Scope.Public);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.CustomToolNamespace).IsEqualTo(original.CustomToolNamespace);
        _ = await Assert.That(result.Designer).IsEqualTo(original.Designer);
        _ = await Assert.That(result.Location).IsEqualTo(original.Location);
        _ = await Assert.That(result.Visibility).IsEqualTo(Item.Scope.Public);
    }
}