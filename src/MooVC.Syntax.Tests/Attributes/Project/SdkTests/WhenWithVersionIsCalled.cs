namespace MooVC.Syntax.Attributes.Project.SdkTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithVersionIsCalled
{
    private const string UpdatedVersion = "UpdatedVersion";

    [Test]
    public async Task GivenVersionThenReturnsUpdatedInstance()
    {
        // Arrange
        Sdk original = SdkTestsData.Create();
        var updated = Snippet.From(UpdatedVersion);

        // Act
        Sdk result = original.WithVersion(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Version).IsEqualTo(updated);
        _ = await Assert.That(result.MinimumVersion).IsEqualTo(original.MinimumVersion);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}