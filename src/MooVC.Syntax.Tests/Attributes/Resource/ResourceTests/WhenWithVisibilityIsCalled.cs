namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

public sealed class WhenWithVisibilityIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Resource original = ResourceTestsData.Create();

        // Act
        Resource result = original.WithVisibility(Resource.Scope.Public);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.CustomToolNamespace.ShouldBe(original.CustomToolNamespace);
        result.Designer.ShouldBe(original.Designer);
        result.Location.ShouldBe(original.Location);
        result.Visibility.ShouldBe(Resource.Scope.Public);
    }
}