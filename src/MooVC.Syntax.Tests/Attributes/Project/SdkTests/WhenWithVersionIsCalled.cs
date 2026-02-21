namespace MooVC.Syntax.Attributes.Project.SdkTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithVersionIsCalled
{
    private const string UpdatedVersion = "UpdatedVersion";

    [Fact]
    public void GivenVersionThenReturnsUpdatedInstance()
    {
        // Arrange
        Sdk original = SdkTestsData.Create();
        var updated = UpdatedVersion;

        // Act
        Sdk result = original.WithVersion(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Version.ShouldBe(updated);
        result.MinimumVersion.ShouldBe(original.MinimumVersion);
        result.Name.ShouldBe(original.Name);
    }
}