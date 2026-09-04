namespace MooVC.Syntax.Resource.ItemTests;

public sealed class WhenWithDesignerIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = new Path("Other.Designer.cs");

        // Act
        Item result = original.WithDesigner(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.CustomToolNamespace).IsEqualTo(original.CustomToolNamespace);
        _ = await Assert.That(result.Designer).IsEqualTo(updated);
        _ = await Assert.That(result.Location).IsEqualTo(original.Location);
        _ = await Assert.That(result.Visibility).IsEqualTo(original.Visibility);
    }
}