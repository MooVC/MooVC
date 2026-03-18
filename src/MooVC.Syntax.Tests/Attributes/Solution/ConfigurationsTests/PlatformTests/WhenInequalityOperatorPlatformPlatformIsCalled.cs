namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenInequalityOperatorPlatformPlatformIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Configurations.Platform? left = default;
        Configurations.Platform? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Configurations.Platform("CustomPlatform");
        var right = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Configurations.Platform("CustomPlatform");
        var right = new Configurations.Platform("OtherPlatform");

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}