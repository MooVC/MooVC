namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithCustomToolNamespaceIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Resource original = ResourceTestsData.Create();
        var updated = "Other.Namespace";

        // Act
        Resource result = original.WithCustomToolNamespace(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.CustomToolNamespace.ShouldBe(updated);
        result.Designer.ShouldBe(original.Designer);
        result.Location.ShouldBe(original.Location);
        result.Visibility.ShouldBe(original.Visibility);
    }
}