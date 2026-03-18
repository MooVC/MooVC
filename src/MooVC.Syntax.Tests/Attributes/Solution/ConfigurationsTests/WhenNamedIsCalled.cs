namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenBuildsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Configurations();
        Configurations.BuildType updated = "Custom";

        // Act
        Configurations result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Builds).IsEqualTo(original.Builds.Concat([updated]));
        _ = await Assert.That(result.Platforms).IsEqualTo(original.Platforms);
    }
}