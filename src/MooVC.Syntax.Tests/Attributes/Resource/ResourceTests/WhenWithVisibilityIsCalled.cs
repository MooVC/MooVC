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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.CustomToolNamespace).IsEqualTo(original.CustomToolNamespace);
        await Assert.That(result.Designer).IsEqualTo(original.Designer);
        await Assert.That(result.Location).IsEqualTo(original.Location);
        await Assert.That(result.Visibility).IsEqualTo(Resource.Scope.Public);
    }
}