namespace MooVC.Syntax.Project.SdkTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Sdk original = SdkTestsData.Create();
        Qualifier updated = "Other.Sdk";

        // Act
        Sdk result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(updated);
        _ = await Assert.That(result.MinimumVersion).IsEqualTo(original.MinimumVersion);
        _ = await Assert.That(result.Version).IsEqualTo(original.Version);
    }
}