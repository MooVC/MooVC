namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenBuildsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Configurations();
        Configurations.BuildType updated = "Custom";

        // Act
        Configurations result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Builds.ShouldBe(original.Builds.Concat([updated]));
        result.Platforms.ShouldBe(original.Platforms);
    }
}