namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        var first = new Configurations.Platform("CustomPlatform");
        var second = new Configurations.Platform("CustomPlatform");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        var first = new Configurations.Platform("CustomPlatform");
        var second = new Configurations.Platform("OtherPlatform");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}