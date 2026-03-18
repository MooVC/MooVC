namespace MooVC.Syntax.Project.SdkTests;

public sealed class WhenWithMinimumVersionIsCalled
{
    private const string UpdatedMinimumVersion = "UpdatedMinimumVersion";

    [Test]
    public async Task GivenMinimumVersionThenReturnsUpdatedInstance()
    {
        // Arrange
        Sdk original = SdkTestsData.Create();
        var updated = Snippet.From(UpdatedMinimumVersion);

        // Act
        Sdk result = original.WithMinimumVersion(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.MinimumVersion).IsEqualTo(updated);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Version).IsEqualTo(original.Version);
    }
}