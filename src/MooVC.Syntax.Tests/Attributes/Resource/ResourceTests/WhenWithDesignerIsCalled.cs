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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.CustomToolNamespace).IsEqualTo(original.CustomToolNamespace);
        await Assert.That(result.Designer).IsEqualTo(updated);
        await Assert.That(result.Location).IsEqualTo(original.Location);
        await Assert.That(result.Visibility).IsEqualTo(original.Visibility);
    }
}