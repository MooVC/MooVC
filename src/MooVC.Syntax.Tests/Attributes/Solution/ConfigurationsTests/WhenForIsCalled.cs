namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenForIsCalled
{
    [Test]
    public async Task GivenPlatformsThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Configurations();
        Configurations.Platform updated = "x64";

        // Act
        Configurations result = original.For(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Platforms).IsEqualTo(original.Platforms.Concat([updated]));
        _ = await Assert.That(result.Builds).IsEqualTo(original.Builds);
    }
}