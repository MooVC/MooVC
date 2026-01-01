namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithDesignerIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Resource original = ResourceTestsData.Create();
        var updated = new Path("Other.Designer.cs");

        // Act
        Resource result = original.WithDesigner(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.CustomToolNamespace.ShouldBe(original.CustomToolNamespace);
        result.Designer.ShouldBe(updated);
        result.Location.ShouldBe(original.Location);
        result.Visibility.ShouldBe(original.Visibility);
    }
}