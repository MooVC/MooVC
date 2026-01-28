namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenForIsCalled
{
    [Fact]
    public void GivenPlatformsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Configurations();
        Configurations.Platform updated = "x64";

        // Act
        Configurations result = original.For(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Platforms.ShouldBe(original.Platforms.Concat([updated]));
        result.Builds.ShouldBe(original.Builds);
    }
}