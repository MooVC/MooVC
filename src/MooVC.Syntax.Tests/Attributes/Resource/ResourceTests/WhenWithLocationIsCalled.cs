namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithLocationIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Resource original = ResourceTestsData.Create();
        var updated = new Path("Other.resx");

        // Act
        Resource result = original.WithLocation(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.CustomToolNamespace.ShouldBe(original.CustomToolNamespace);
        result.Designer.ShouldBe(original.Designer);
        result.Location.ShouldBe(updated);
        result.Visibility.ShouldBe(original.Visibility);
    }
}