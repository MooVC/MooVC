namespace MooVC.Syntax.CSharp.Attributes.Project.SdkTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Sdk original = SdkTestsData.Create();
        Qualifier updated = "Other.Sdk";

        // Act
        Sdk result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.MinimumVersion.ShouldBe(original.MinimumVersion);
        result.Version.ShouldBe(original.Version);
    }
}