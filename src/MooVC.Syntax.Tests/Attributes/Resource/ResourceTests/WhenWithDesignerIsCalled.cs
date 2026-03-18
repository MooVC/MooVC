namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithDesignerIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Resource original = ResourceTestsData.Create();
        var updated = new Path("Other.Designer.cs");

        // Act
        Resource result = original.WithDesigner(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.CustomToolNamespace).IsEqualTo(original.CustomToolNamespace);
        _ = await Assert.That(result.Designer).IsEqualTo(updated);
        _ = await Assert.That(result.Location).IsEqualTo(original.Location);
        _ = await Assert.That(result.Visibility).IsEqualTo(original.Visibility);
    }
}