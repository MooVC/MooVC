namespace MooVC.Syntax.Attributes.Project.SdkTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithMinimumVersionIsCalled
{
    private const string UpdatedMinimumVersion = "UpdatedMinimumVersion";

    [Fact]
    public void GivenMinimumVersionThenReturnsUpdatedInstance()
    {
        // Arrange
        Sdk original = SdkTestsData.Create();
        var updated = Snippet.From(UpdatedMinimumVersion);

        // Act
        Sdk result = original.WithMinimumVersion(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.MinimumVersion.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Version.ShouldBe(original.Version);
    }
}