namespace MooVC.Syntax.Attributes.Project.SdkTests;

using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.MinimumVersion).IsEqualTo(updated);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Version).IsEqualTo(original.Version);
    }
}