namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualityOperatorPlatformPlatformIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Configurations.Platform? left = default;
        Configurations.Platform? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Configurations.Platform("CustomPlatform");
        var right = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Configurations.Platform("CustomPlatform");
        var right = new Configurations.Platform("OtherPlatform");

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}