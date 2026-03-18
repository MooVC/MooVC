namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

public sealed class WhenWithVisibilityIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Resource original = ResourceTestsData.Create();

        // Act
        Resource result = original.WithVisibility(Resource.Scope.Public);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.CustomToolNamespace).IsEqualTo(original.CustomToolNamespace);
        _ = await Assert.That(result.Designer).IsEqualTo(original.Designer);
        _ = await Assert.That(result.Location).IsEqualTo(original.Location);
        _ = await Assert.That(result.Visibility).IsEqualTo(Resource.Scope.Public);
    }
}